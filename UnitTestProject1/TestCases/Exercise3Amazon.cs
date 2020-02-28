using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1.Logger;
using AutomationTestConsole.TestData;

/*
 Flow to complete:
Go to Amazon.com.mx
Login with valid credentials
Search for product: Samsung Galaxy S9 64GB
Select first product and save the price
Click on the product
Validate first price vs detail price
Click on Add to Cart
Validate again, first price vs current price
...
Validate that the Shop car has 1 as a number
Search for another product: Alienware Aw3418DW
Select First product
Add to Cart
Verify that the cart number is now 2
End of test
 */


namespace UnitTestProject1
{   
    [TestClass]
    public class Activity3Amazon : EneidaTest
    {
        private bool startAsConsoleApp = false;

        public bool StartAsConsoleApp { get => startAsConsoleApp; set => startAsConsoleApp = value; }

        [TestInitialize] 
        public void BeforeEachTest()
        {
            InitializeFramework(StartAsConsoleApp);
            Pages.AmazonPage.InitElements();
            Parameters.SetCredentials();
        }        

        [TestCategory("Shopping"), Priority(1), TestMethod]
        public void AmazonTest()
        {
            Pages.AmazonPage
                .GoTo()
                .LoginWithCredentials()
                .SearchProduct("Samsung Galaxy S9 64GB")
                .SelectFirstProduct()
                .AddToCart()
                .OpenCart()
                .ComparePrices1vs2()
                .ComparePrices1vs3()
                .CardItemsCount(1)
                .SearchProduct("Alienware")
                .SelectFirstProduct()
                .AddToCart()
                .CardItemsCount(2);

            Pages.StandardMethods.Wait(2000);

            Log.Info("All validation passed");
        }

        [TestCategory("Shopping"), Priority(1), TestMethod]
        public void AmazonTest_StepByStep()
        {
            Pages.AmazonPage
                .GoTo()
                .LoginWithCredentials();

            Pages.StandardMethods
                 .Wait(4000);

            Pages.AmazonPage.SearchProduct("Samsung Galaxy S9 64GB");
            Pages.AmazonPage.SelectFirstProduct();
            Pages.AmazonPage.AddToCart();
            Pages.AmazonPage.OpenCart();
            Pages.AmazonPage.ComparePrices1vs2();
            Pages.AmazonPage.ComparePrices1vs3();
            Pages.AmazonPage.CardItemsCount(1);
            Pages.AmazonPage.SearchProduct("Alienware");
            Pages.AmazonPage.SelectFirstProduct();
            Pages.AmazonPage.AddToCart();
            Pages.AmazonPage.CardItemsCount(2);
            Pages.StandardMethods.Wait(2000);

            Log.Info("All validation passed");
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            CleanUpTest();
        }
    }
}
