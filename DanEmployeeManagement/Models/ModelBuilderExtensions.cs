using Microsoft.EntityFrameworkCore;

namespace DanEmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Daniela",
                    Department = Depts.Design,
                    Email = "daniela@yahoo.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "John",
                    Department = Depts.Drive,
                    Email = "john@yahoo.com"
                });
        }
    }
}
