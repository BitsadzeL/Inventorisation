using Microsoft.EntityFrameworkCore;
using SchoolInventory.Domain.Entities;

namespace SchoolInventory.Infrastructure.Data;

public static class EntityConfigurations
{
    public static void ConfigureCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasIndex(c => c.Name)
                .IsUnique();

            entity.HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public static void ConfigureLocations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(l => l.Id);

            entity.Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(l => l.RoomName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(l => l.Building)
                .HasMaxLength(50);

            entity.Property(l => l.Floor)
                .HasMaxLength(20);

            entity.HasIndex(l => l.RoomName);

            entity.HasMany(l => l.Items)
                .WithOne(i => i.Location)
                .HasForeignKey(i => i.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public static void ConfigureEmployees(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);



            entity.HasIndex(e => new { e.FirstName, e.LastName });

            entity.HasMany(e => e.StatusChanges)
                .WithOne(sh => sh.ChangedBy)
                .HasForeignKey(sh => sh.ChangedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public static void ConfigureItems(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(i => i.Id);

            entity.Property(i => i.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(i => i.InventoryNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(i => i.Description)
                .HasMaxLength(500);

            entity.Property(i => i.PurchasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(i => i.Status)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(i => i.CategoryId)
                .IsRequired();

            entity.Property(i => i.LocationId)
                .IsRequired();

            entity.HasIndex(i => i.InventoryNumber)
                .IsUnique();

            entity.HasIndex(i => i.Status);

            entity.HasIndex(i => i.CategoryId);

            entity.HasIndex(i => i.LocationId);

            entity.HasIndex(i => new { i.CategoryId, i.Status });

            entity.HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Location)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(i => i.StatusHistory)
                .WithOne(sh => sh.Item)
                .HasForeignKey(sh => sh.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static void ConfigureItemStatusHistory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemStatusHistory>(entity =>
        {
            entity.HasKey(sh => sh.Id);

            entity.Property(sh => sh.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(sh => sh.FromStatus)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(sh => sh.ToStatus)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(sh => sh.Reason)
                .HasMaxLength(500);

            entity.HasIndex(sh => sh.ItemId);

            entity.HasIndex(sh => sh.ChangedAt);
        });
    }

    public static void ConfigurePositions(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>(entity =>
        {
            
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            
            entity.HasIndex(p => p.Name)
                  .IsUnique(); 

            
            entity.HasMany(p => p.Employees)
                  .WithOne(e => e.Position)
                  .HasForeignKey(e => e.PositionId)
                  .OnDelete(DeleteBehavior.Restrict); 
        });

    }
}
