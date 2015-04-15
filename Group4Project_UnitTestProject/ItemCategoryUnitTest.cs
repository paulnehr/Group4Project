using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Group4Project_ClassLibrary;

namespace Group4Project_UnitTestProject
{
    [TestClass]
    public class ItemCategoryUnitTest
    {
        [TestMethod]
        public void GetCategoriesTestMethod()
        {
            int expectedNumberOfCategories = 5;
            int actualNumberOfCategories = 0;

            DataSet dataset = ItemCategory.GetCategories();
            actualNumberOfCategories = dataset.Tables[0].Rows.Count;

            Assert.AreEqual(expectedNumberOfCategories, actualNumberOfCategories, 
                "The actual number of categories differs from the expected");
        }
    }
}
