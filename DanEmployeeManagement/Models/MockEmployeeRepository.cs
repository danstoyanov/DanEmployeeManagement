using System;
using System.Linq;
using System.Collections.Generic;

namespace DanEmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public MockEmployeeRepository()
        {
            this.employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mincho", Email = "mincho@abv.bg", Department = "Build  👷‍♂️"},
                new Employee() {Id = 2, Name = "Galin", Email = "galin@abv.bg", Department = "Drive  🚗"},
                new Employee() {Id = 3, Name = "Danko", Email = "danko@abv.bg", Department = "Design  🎨"}
            };
        }

        public Employee GetEmployee(int Id)
        {
            return employees.FirstOrDefault(e => e.Id == Id);
        }
    }
}
