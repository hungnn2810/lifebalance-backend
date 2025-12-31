using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
{
    public void Configure(EntityTypeBuilder<UserInformation> builder)
    {
        builder.ToTable("user_information");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("user_id");
        builder.Property(x => x.Avatar).HasColumnName("avatar");
        builder.Property(x => x.Age).HasColumnName("age");
        builder.Property(x => x.Weight).HasColumnName("weight");
        builder.Property(x => x.Height).HasColumnName("height");
        builder.Property(x => x.Gender).HasColumnName("gender").HasConversion<string>();
        builder.Property(x => x.FitnessGoals).HasColumnType("text[]").HasColumnName("fitness_goals");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
    }
}