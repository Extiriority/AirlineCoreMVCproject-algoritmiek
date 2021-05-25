using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class CustomerLoginViewModel
    {
        [Required(ErrorMessage = "Please enter email!")]
        [Display(Name = "Enter email: ")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [Display(Name = "Enter password: ")]
        public string password { get; set; }
    }
}
