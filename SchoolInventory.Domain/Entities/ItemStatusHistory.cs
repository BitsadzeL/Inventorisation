using SchoolInventory.Domain.Enums;

namespace SchoolInventory.Domain.Entities;

public class ItemStatusHistory
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public ItemStatus FromStatus { get; set; }
    public ItemStatus ToStatus { get; set; }
    public DateTime ChangedAt { get; set; }
    public int ChangedByEmployeeId { get; set; }
    public string? Reason { get; set; }

    
    public Item Item { get; set; } = null!;
    public Employee ChangedBy { get; set; } = null!;
}