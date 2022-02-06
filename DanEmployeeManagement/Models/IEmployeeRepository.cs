using System.Collections.Generic;

namespace DanEmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        IEnumerable<Employee> GetAllEmployee();

        Employee Add(Employee employee);

        Employee Update(Employee employeeUpdate);

        Employee Delete(int id);
    }
}
