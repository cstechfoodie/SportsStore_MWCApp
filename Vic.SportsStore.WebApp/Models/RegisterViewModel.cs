using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vic.SportsStore.WebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Password must be bewtween 6 and 10 digits")]
        [DataType(DataType.Password)]
        [Display(Name = "Pawword")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Pawword")]
        public string ComfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"\d{10,10}", ErrorMessage = "Phone number should be 10 digits")]
        [DataType(DataType.PhoneNumber)]
        public string Cell { get; set; }
    }
}