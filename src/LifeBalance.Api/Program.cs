using System.Text;
using LifeBalance.Api.Middlewares;
using LifeBalance.Application.Exceptions.Filters;
using LifeBalance.Application.Extensions;
using LifeBalance.Persistence.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LifeBalance.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var secret = builder.Configuration["Jwt:Secret"]
                    ?? throw new InvalidOperationException("Jwt:Secret not configured");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secret)
                    ),

                    ClockSkew = TimeSpan.Zero // rất quan trọng
                };
            });

        builder.Services.AddAuthorization();
        builder.Services.AddControllers(options => { options.ExceptionHandling(); })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffff";
                options.SerializerSettings.DateParseHandling = DateParseHandling.None;
            });


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplicationService();
        builder.Services.AddPersistenceService();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseWhen(
            c => c.Request.Path.HasValue && !c.Request.Path.Value.StartsWith("/auth"),
            b => b.UseMiddleware<UserContextMiddleware>()
        );

        app.MapControllers();

        app.Run();
    }
}