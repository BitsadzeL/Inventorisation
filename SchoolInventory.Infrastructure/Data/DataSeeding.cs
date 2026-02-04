using Microsoft.EntityFrameworkCore;
using SchoolInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolInventory.Infrastructure.Data
{
    public static class DataSeeding
    {
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Principal" },
                new Position { Id = 2, Name = "Vice Principal" },
                new Position { Id = 3, Name = "Administrator" },
                new Position { Id = 4, Name = "Math Teacher" },
                new Position { Id = 5, Name = "Biology Teacher" },
                new Position { Id = 6, Name = "Chemistry Teacher" },
                new Position { Id = 7, Name = "Physics Teacher" },
                new Position { Id = 8, Name = "History Teacher" },
                new Position { Id = 9, Name = "Technician" },
                new Position { Id = 10, Name = "Support Staff" }
            );
        }


        public static void SeedEmployees(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                
                new Employee { Id = 1, FirstName = "Luka", LastName = "Bitsadze", PositionId = 4 }, 
                new Employee { Id = 2, FirstName = "Ana", LastName = "Gogolashvili", PositionId = 5 }, 
                new Employee { Id = 3, FirstName = "Giorgi", LastName = "Kapanadze", PositionId = 6 }, 
                new Employee { Id = 4, FirstName = "Nino", LastName = "Zurabishvili", PositionId = 7 },
                new Employee { Id = 5, FirstName = "David", LastName = "Svanidze", PositionId = 8 }, 

                
                new Employee { Id = 6, FirstName = "Mariam", LastName = "Chikhladze", PositionId = 1 }, 
                new Employee { Id = 7, FirstName = "Irakli", LastName = "Bakhtadze", PositionId = 2 }, 
                new Employee { Id = 8, FirstName = "Salome", LastName = "Tsertsvadze", PositionId = 3 }, 
                new Employee { Id = 9, FirstName = "Levan", LastName = "Kiknadze", PositionId = 9 }, 
                new Employee { Id = 10, FirstName = "Tamar", LastName = "Lomidze", PositionId = 10 } 
            );
        }
    }
}
