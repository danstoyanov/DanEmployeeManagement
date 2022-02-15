using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using DanEmployeeManagement.Utilities;

namespace DanEmployeeManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomain (allowedDomain: "danemployee.com", 
            ErrorMessage = "Email domain must be danemployee.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
        ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
