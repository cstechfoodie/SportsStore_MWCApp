using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vic.SportsStore.WebApp.Models
{
    public class CustomerLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Password must be between 6 and 10 digits")]
        public string Pwd { get; set; }
    }
}