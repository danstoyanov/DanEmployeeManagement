using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanEmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Depts Department { get; set; }
    }
}
