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
                new Employee() {Id = 1, Name = "Mincho", Email = "mincho@abv.bg", Department = Depts.Build},
                new Employee() {Id = 2, Name = "Galin", Email = "galin@abv.bg", Department = Depts.Design},
                new Employee() {Id = 3, Name = "Danko", Email = "danko@abv.bg", Department = Depts.Drive}
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.employees;
        }

        public Employee GetEmployee(int Id)
        {
            return employees.FirstOrDefault(e => e.Id == Id);
        }
    }
}
