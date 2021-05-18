using ClassLib.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int customerId { get; set; }
        [Required(ErrorMessage = "A first name is required to proceed!")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "A last name is required to proceed!")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "An Email adress is required to proceed!")]
        public string email { get; set; }
        [Required(ErrorMessage = "An phone number is required to proceed!")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "An date of your birth is required to proceed!")]
        public DateTime dateOfBirth { get; set; }
        [Required(ErrorMessage = "A gender is required to proceed!")]
        public string gender { get; set; }
        [Required(ErrorMessage = "An username is required to proceed!")]
        public string username { get; set; }
        [Required(ErrorMessage = "A password is required to proceed!")]
        public string password { get; set; }

        public CustomerViewModel()
        {

        }
        public CustomerViewModel(Customer customer)
        {
            this.customerId     = customer.customerId;
            this.firstName      = customer.firstName;
            this.lastName       = customer.lastName;
            this.email          = customer.email;
            this.phoneNumber    = customer.phoneNumber;
            this.dateOfBirth    = customer.dateOfBirth;
            this.gender         = customer.gender;
            this.username       = customer.username;
            this.password       = customer.password;

        }
    }
}
