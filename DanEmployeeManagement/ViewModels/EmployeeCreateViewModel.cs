using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

using DanEmployeeManagement.Models;
using System.Collections.Generic;

namespace DanEmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be max 50 characters long !")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid emails format !")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }

        [Required]
        public Depts Department { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
