namespace SchoolInventory.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    
    public int PositionId { get; set; }           
    public Position Position { get; set; } = null!;  

    
    public ICollection<ItemStatusHistory> StatusChanges { get; set; } = new List<ItemStatusHistory>();
}
