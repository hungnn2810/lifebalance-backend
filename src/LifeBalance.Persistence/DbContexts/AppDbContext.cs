using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Persistence.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
    }
}