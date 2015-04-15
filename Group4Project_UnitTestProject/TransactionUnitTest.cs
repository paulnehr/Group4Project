using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group4Project_ClassLibrary;
using System.Xml;
using System.Data;

namespace Group4Project_UnitTestProject
{
    [TestClass]
    public class TransactionUnitTest
    {
        [TestMethod]
        public void UpdateTransactionRatingTestMethod()
        {
            int transactionRating = 3;
            int transactionNum = 10000;
            string errorMessage;
            bool updateSuccess;

            updateSuccess =
                Transaction.UpdateTransactionRating(transactionRating, transactionNum, out errorMessage);
            Assert.IsTrue(updateSuccess);

            transactionRating = 6;

            updateSuccess =
                Transaction.UpdateTransactionRating(transactionRating, transactionNum, out errorMessage);
            Assert.IsFalse(updateSuccess);

            string expectedErrorMessage = "Must enter a whole number between 1 and 5";
            Assert.AreEqual(expectedErrorMessage, errorMessage);
        }

        [TestMethod]
        public void CreateTransactionTestMethod()
        {
            int transactionNum;
            int transactionPrice = 50;
            string transactionType = "buy now";
            int userID = 11;
            int itemNum = 1000; //testing with an already sold item first, which is unavailable
            DateTime transactionDateTime = new DateTime(2015, 01, 08);
            string transactionStatus = "completed";
            string errorMessage;
            bool transactionSuccess;

            transactionSuccess = Transaction.CreateTransaction(out transactionNum,
                transactionPrice, transactionType, userID, transactionStatus, itemNum,
                transactionDateTime, out errorMessage);
            Assert.IsFalse(transactionSuccess, "Item has already been sold - should fail");

            string expectedErrorMessage = "Item is no longer available";
            Assert.AreEqual(expectedErrorMessage, errorMessage);

            itemNum = 1001; //testing with an unsold item, should pass

            transactionSuccess = Transaction.CreateTransaction(out transactionNum,
                transactionPrice, transactionType, userID, transactionStatus, itemNum,
                transactionDateTime, out errorMessage);
            Assert.IsTrue(transactionSuccess, "Item is avaiable - should pass");                   

            bool deleteSuccess = Transaction.DeleteTransaction(transactionNum);
            Assert.IsTrue(deleteSuccess);

        }

        [TestMethod]
        public void GetTransactionDetailTestMethod()
        {
            int expectedNumberOfRows = 1;
            int actualNumberOfRows = 0;
            int transactionNum = 10000;

            DataSet dataset = Transaction.GetTransactionDetail(transactionNum);
            actualNumberOfRows = dataset.Tables[0].Rows.Count;
            Assert.AreEqual(expectedNumberOfRows, actualNumberOfRows, "The transaction number is invalid");
        }

        [TestMethod]
        public void GetTransactionHistoryTestMethod()
        {
            int expectedNumberOfTransactions = 2;
            int actualNumberOfTransactions = 0;
            int userID = 12;

            DataSet dataset = Transaction.GetTransactionHistory(userID);
            actualNumberOfTransactions = dataset.Tables[0].Rows.Count;
            Assert.AreEqual(expectedNumberOfTransactions, actualNumberOfTransactions, 
                "The actual number of transactions varies from expected");
        }           

    }

}