using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group4Project_ClassLibrary;
using System.Data;

namespace Group4Project_UnitTestProject
{
    [TestClass]
    public class ItemListingUnitTest
    {
        [TestMethod]
        public void ListItemTestMethod()
        {
            int itemNum;
            string itemName = "Test";
            string itemDescription = "Test";
            int itemPrice = 100;
            string itemPhoto = "Test";
            int categoryNum = 1; 
            int userID = 1; //testing with invalid customer ID initially
            string errorMessage;
            bool listingSuccess;

            listingSuccess = ItemListing.ListItem(out itemNum, itemName, itemDescription, itemPrice, itemPhoto, categoryNum, userID, out errorMessage);
            Assert.IsFalse(listingSuccess, "Customer ID is invalid - should fail");

            string expectedErrorMessage = "Customer ID is invalid";
            Assert.AreEqual(expectedErrorMessage, errorMessage);

            userID = 11; //testing with valid customer ID
            
            listingSuccess = ItemListing.ListItem(out itemNum, itemName, itemDescription, itemPrice, itemPhoto, categoryNum, userID, out errorMessage);
            Assert.IsTrue(listingSuccess, "Customer ID is valid - should pass");

            bool removeSuccess = ItemListing.RemoveItemListing(itemNum);
            Assert.IsTrue(removeSuccess);         
        }

        [TestMethod]
        public void GetAllItemsForCategoryTestMethod()
        {
            int categoryNum = 1;
            int expectedNumberOfListings = 2;
            int actualNumberOfListings = 0;

            DataSet dataSet = ItemListing.GetAllItemsForCategory(categoryNum);

            actualNumberOfListings = dataSet.Tables[0].Rows.Count;

            Assert.AreEqual(expectedNumberOfListings, actualNumberOfListings,
                "Actual number of items varies from expected");
        }

        [TestMethod]
        public void GetItemListingDetailTestMethod()
        {
            int itemNum = 1010;
            int expectedNumberOfRows = 1;
            int actualNumberOfRows = 0;

            DataSet dataSet = ItemListing.GetItemListingDetail(itemNum);

            actualNumberOfRows = dataSet.Tables[0].Rows.Count;

            Assert.AreEqual(expectedNumberOfRows, actualNumberOfRows,
                "Actual number of rows varies from expected");
        }

        [TestMethod]
        public void GetAllItemsForUserTestMethod()
        {
            int userID = 12;
            int expectedNumberOfItems = 3;
            int actualNumberOfItems = 0;

            DataSet dataSet = ItemListing.GetAllItemsForUser(userID);

            actualNumberOfItems = dataSet.Tables[0].Rows.Count;

            Assert.AreEqual(expectedNumberOfItems, actualNumberOfItems,
                "Actual number of items varies from expected");
        }

    }
}
