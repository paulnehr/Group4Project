using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group4Project_ClassLibrary;

namespace Group4Project_UnitTestProject
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void RegisterCustomerTestMethod()
        {
            int userID;
            string userName = "andy.bevin"; //testing with an existing user first
            string userAddress = "7 Seventh Street";
            string userPhone = "304-777-7777";
            string userEmail = "nick.breitsameter@gmail.com";
            DateTime dateRegistered = new DateTime(2015, 4, 6);
            string errorMessage;
            bool registerSuccess = true;

            registerSuccess = Customer.RegisterCustomer(out userID, userName, userAddress, userPhone
                , userEmail, dateRegistered, out errorMessage);
            Assert.IsFalse(registerSuccess, "username already exists - should fail");

            string expectedErrorMessage = "This username is already associated with a customer";
            Assert.AreEqual(expectedErrorMessage, errorMessage);

            userName = "nick.breitsameter"; //testing with a unique username

            registerSuccess = Customer.RegisterCustomer(out userID, userName, userAddress, userPhone
                , userEmail, dateRegistered, out errorMessage);
            Assert.IsTrue(registerSuccess, "username is unique - should pass");

            bool deleteSuccess = Customer.DeleteAccount(userID);
            Assert.IsTrue(deleteSuccess);
        }
    }
}
