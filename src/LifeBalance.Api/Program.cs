using LifeBalance.Application.Exceptions.Filters;
using LifeBalance.Application.Extensions;
using LifeBalance.Persistence.Extensions;
using MediatR;
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

        // Add services to the container.
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

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}