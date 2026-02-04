using Microsoft.EntityFrameworkCore;
using SchoolInventory.Domain.Entities;

namespace SchoolInventory.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ItemStatusHistory> ItemStatusHistory { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureLocations();
        modelBuilder.ConfigureEmployees();
        modelBuilder.ConfigureItems();
        modelBuilder.ConfigureItemStatusHistory();
        modelBuilder.ConfigurePositions();

        modelBuilder.SeedPositions();
        modelBuilder.SeedEmployees();
    }


}