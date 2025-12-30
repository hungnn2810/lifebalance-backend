using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class WorkoutStepConfiguration : IEntityTypeConfiguration<WorkoutStep>
{
    public void Configure(EntityTypeBuilder<WorkoutStep> builder)
    {
        builder.ToTable("workout_steps");
        builder.HasKey(ws => ws.Id);
        builder.Property(ws => ws.Id).HasColumnName("id");
        builder.Property(ws => ws.WorkoutId).HasColumnName("workout_id");
        builder.Property(ws => ws.Title).HasColumnName("title");
        builder.Property(ws => ws.Index).HasColumnName("index");
        builder.Property(ws => ws.Description).HasColumnName("description");
        builder.Property(ws => ws.CreatedAt).HasColumnName("created_at");
        builder.Property(ws => ws.UpdatedAt).HasColumnName("updated_at");
        builder.HasMany(ws => ws.Medias).WithOne(m => m.WorkoutStep).HasForeignKey(m => m.WorkoutStepId);
    }
}