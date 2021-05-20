using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Interface
{
    public struct CustomerDto
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
    }
}
