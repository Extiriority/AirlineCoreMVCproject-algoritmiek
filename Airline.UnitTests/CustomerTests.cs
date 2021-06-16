using NUnit.Framework;
using System;
using Airline.UnitTests.MockData;
using ClassLib.Logic;

namespace Airline.UnitTests
{
    class CustomerTests
    {
        [Test]
        public void verifyLogin_MockCustomers_AreEqual()
        {
            // Arrange
            CustomerDalStub customerDalStub = new();
            CustomerContainer customerContainer = new(customerDalStub);
            Customer customer = new(customerDalStub);

            string validEmail1 = "Tem@live.com";
            string validPassword1 = "Tommy12";

            string validEmail2 = "Tem@live.com";
            string invalidPassword1 = "randomTest2";

            string invalidEmail1 = "lolll@gmail.com";
            string validPassword2 = "TRran4";

            string validEmail3 = "Wellempje@game.net";
            string validPassword3 = "rompot3";

            // Act & Assert
            Assert.DoesNotThrow(() => customerContainer.verifyLogin(validEmail1, validPassword1));
            Assert.Catch<CustomerLoginException>(() => customerContainer.verifyLogin(validEmail2, invalidPassword1));
            Assert.Catch<InvalidOperationException>(() => customerContainer.verifyLogin(invalidEmail1, validPassword2));
            Assert.DoesNotThrow(() => customerContainer.verifyLogin(validEmail3, validPassword3));

        }
    }
}