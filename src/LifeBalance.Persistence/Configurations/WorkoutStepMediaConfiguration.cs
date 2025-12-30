using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBalance.Persistence.Configurations;

public class WorkoutStepMediaConfiguration : IEntityTypeConfiguration<WorkoutStepMedia>
{
    public void Configure(EntityTypeBuilder<WorkoutStepMedia> builder)
    {
        builder.ToTable("workout_step_medias");
        builder.HasKey(wsm => wsm.Id);
        builder.Property(wsm => wsm.Id).HasColumnName("id");
        builder.Property(wsm => wsm.WorkoutStepId).HasColumnName("workout_step_id");
        builder.Property(wsm => wsm.MediaType).HasColumnName("media_type").HasConversion<string>();
        builder.Property(wsm => wsm.ObjectKey).HasColumnName("object_key");
        builder.Property(wsm => wsm.Url).HasColumnName("url");
        builder.Property(wsm => wsm.SortOrder).HasColumnName("sort_order");
        builder.Property(wsm => wsm.CreatedAt).HasColumnName("created_at");
    }
}