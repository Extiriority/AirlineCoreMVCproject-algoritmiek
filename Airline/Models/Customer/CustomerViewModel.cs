using ClassLib.Logic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Enter Email adress")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Enter birthdate")]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter gender type")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Confirm password doesn't match")]
        public string confirmPassword { get; set; }
        public bool isAdmin { get; set; }

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
            this.password       = customer.password;
            this.isAdmin        = customer.isAdmin;
        }
    }
}
