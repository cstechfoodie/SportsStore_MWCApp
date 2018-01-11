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
        public string Pwd { get; set; }
    }
}