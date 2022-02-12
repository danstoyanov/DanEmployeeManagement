using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DanEmployeeManagement.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SqlEmployeeRepository> logger;

        public SqlEmployeeRepository(
            AppDbContext context, 
            ILogger<SqlEmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger; 
        }

        public Employee Add(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = this.context.Employees.Find(id);

            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                this.context.SaveChanges();
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Crititcal Log");

            return this.context.Employees.Find(id);
        }

        public Employee Update(Employee employeeUpdate)
        {
            var employee = this.context.Employees.Attach(employeeUpdate);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            this.context.SaveChanges();

            return employeeUpdate;
        }
    }
}
