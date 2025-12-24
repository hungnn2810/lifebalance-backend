using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.Email).HasColumnName("email");
        builder.Property(u => u.Name).HasColumnName("name");
        builder.Property(u => u.Password).HasColumnName("password");
        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
        builder.HasMany(u => u.UserLogins).WithOne(x => x.User).HasForeignKey(u => u.UserId);
        builder.HasOne(u => u.UserInformation).WithOne().HasForeignKey<UserInformation>(ui => ui.Id);
        builder.HasMany(u => u.UserTracking).WithOne(ut => ut.User).HasForeignKey(ut => ut.UserId);
        builder.HasMany(u => u.RefreshTokens).WithOne(rt => rt.User).HasForeignKey(rt => rt.UserId);
    }
}