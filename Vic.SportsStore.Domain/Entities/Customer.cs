using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vic.SportsStore.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(9)]
        public int Cell { get; set; }

        [EmailAddress(ErrorMessage = "The email format is not valid")]
        public string Email { get; set; }

        public string Password { get; set; }

        
    }
}
