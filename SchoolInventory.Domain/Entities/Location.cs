using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolInventory.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string? Building { get; set; }
        public string? Floor { get; set; }

        // Navigation property
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
