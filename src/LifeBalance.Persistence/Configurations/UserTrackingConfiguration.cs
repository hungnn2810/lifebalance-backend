using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class UserTrackingConfiguration : IEntityTypeConfiguration<UserTracking>
{
    public void Configure(EntityTypeBuilder<UserTracking> builder)
    {
        builder.ToTable("user_tracking");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.Steps).HasColumnName("steps");
        builder.Property(x => x.Calories).HasColumnName("calories");
        builder.Property(x => x.WorkoutStreak).HasColumnName("workout_streak");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
    }
}