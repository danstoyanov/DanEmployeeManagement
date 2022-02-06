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

        public Employee Add(Employee employee)
        {
            employee.Id = this.employees.Max(e => e.Id) + 1;

            this.employees.Add(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = this.employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                this.employees.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.employees;
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeUpdate)
        {
            var employee = this.employees.FirstOrDefault(e => e.Id == employeeUpdate.Id);

            if (employee != null)
            {
                employee.Name = employeeUpdate.Name;
                employee.Email = employeeUpdate.Email;
                employee.Department = employeeUpdate.Department;
            }

            return employee;
        }
    }
}
