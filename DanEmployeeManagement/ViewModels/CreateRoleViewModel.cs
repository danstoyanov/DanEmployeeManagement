using System.ComponentModel.DataAnnotations;

namespace DanEmployeeManagement.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
