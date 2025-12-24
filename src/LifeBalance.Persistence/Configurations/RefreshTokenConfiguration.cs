using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LifeBalance.Persistence.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        var converter = new ValueConverter<byte[], string>(
            v => Convert.ToBase64String(v), // byte[] -> string (lưu DB)
            v => Convert.FromBase64String(v) // string -> byte[]
        );

        builder.ToTable("refresh_tokens");
        builder.HasKey(rt => rt.Id);
        builder.Property(rt => rt.Id).HasColumnName("id");
        builder.Property(rt => rt.UserId).HasColumnName("user_id");
        builder.Property(rt => rt.TokenHash).HasColumnName("token_hash").HasConversion(converter);
        builder.Property(rt => rt.CreatedAt).HasColumnName("created_at");
        builder.Property(rt => rt.ExpiresAt).HasColumnName("expires_at");
        builder.Property(rt => rt.RevokedAt).HasColumnName("revoked_at");
    }
}