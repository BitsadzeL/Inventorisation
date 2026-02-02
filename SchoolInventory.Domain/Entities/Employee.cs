namespace SchoolInventory.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Position { get; set; }

    // Navigation property
    public ICollection<ItemStatusHistory> StatusChanges { get; set; } = new List<ItemStatusHistory>();
}