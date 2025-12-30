using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("workouts");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).HasColumnName("id");
        builder.Property(w => w.Name).HasColumnName("name");
        builder.Property(w => w.Title).HasColumnName("title");
        builder.Property(w => w.Type).HasColumnName("type").HasConversion<string>();
        builder.Property(w => w.Notes).HasColumnName("notes");
        builder.Property(w => w.Benefits).HasColumnType("text[]").HasColumnName("benefits");
        builder.Property(w => w.EstimatedCalories).HasColumnName("estimated_calories");
        builder.Property(w => w.Order).HasColumnName("order");
        builder.Property(w => w.CreatedAt).HasColumnName("created_at");
        builder.Property(w => w.UpdatedAt).HasColumnName("updated_at");
        builder.HasMany(w => w.Steps).WithOne(w => w.Workout).HasForeignKey(ws => ws.WorkoutId);
    }
}