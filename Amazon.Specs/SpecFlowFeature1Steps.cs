using Automation1;
using AutomationTestConsole.TestData;
using System;
using TechTalk.SpecFlow;
using UnitTestProject1;

namespace Amazon.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps : EneidaTest
    {
        /// ..........................................................................
        /// .................................. G I V E N .............................
        /// ..........................................................................

        [Given(@"My Framework is ready")]
        public void GivenMyFrameworkIsReady()
        {
            InitializeFramework();
            Pages.AmazonPage.InitElements();
        }
        
        [Given(@"I am an existing Amazon User")]
        public void GivenIAmAnExistingAmazonUser()
        {
            Parameters.SetCredentials();
        }
        
        [Given(@"I am logged to Amazon")]
        public void GivenIAmLoggedToAmazon()
        {
            Pages.AmazonPage
                .GoTo()
                .LoginWithCredentials();                
        }

        /// ..........................................................................
        /// .................................. W H E N .............................
        /// ..........................................................................



        [When(@"I search for following product (.*)")]
        public void WhenISearchForFollowingProduct(string productName)
        {
            Pages.AmazonPage.SearchProduct(productName);
        }

        [When(@"I select first found product")]
        public void WhenSelectFirst()
        {
            Pages.AmazonPage.SelectFirstProduct();
        }

        [When(@"I add Item to cart")]
        public void WhenIAddItemToCart()
        {
            Pages.AmazonPage.AddToCart();
        }

        [When(@"I open Cart")]
        public void WhenIOpenCart()
        {
            Pages.AmazonPage.OpenCart();
        }

        /// ..........................................................................
        /// .................................. T H E N  .............................
        /// ..........................................................................

        [Then(@"Compare prices 1 vs 2")]
        public void FirstComparation()
        {
            Pages.AmazonPage.ComparePrices1vs2();
        }

        [Then(@"Compare prices 1 vs 3")]
        public void SecondComparation()
        {
            Pages.AmazonPage.ComparePrices1vs3();
        }

        [Then(@"Cart should display count as (.*)")]
        public void ThenCartShouldDisplayCountAs(int itemsCount)
        {
            Pages.AmazonPage.CardItemsCount(itemsCount);
        }

        [Then(@"Finally test is completed")]
        public void ThenFinallyTestIsCompleted()
        {
            CleanUpTest();
        }
    }
}
