using SchoolInventory.Domain.Enums;

namespace SchoolInventory.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string InventoryNumber { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal PurchasePrice { get; set; }
    public ItemStatus Status { get; set; }

    
    public int CategoryId { get; set; }
    public int LocationId { get; set; }

    
    public Category Category { get; set; } = null!;
    public Location Location { get; set; } = null!;
    public ICollection<ItemStatusHistory> StatusHistory { get; set; } = new List<ItemStatusHistory>();

    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}