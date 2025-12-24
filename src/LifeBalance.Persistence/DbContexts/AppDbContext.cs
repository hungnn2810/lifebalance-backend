using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Persistence.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserInformation> UserInformation { get; set; }
    public DbSet<UserTracking> UserTracking { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutStep> WorkoutSteps { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
        modelBuilder.ApplyConfiguration(new UserInformationConfiguration());
        modelBuilder.ApplyConfiguration(new UserTrackingConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutStepConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
    }
}