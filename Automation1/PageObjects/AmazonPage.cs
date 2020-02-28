using Automation1.Logger;
using Automation1.PageObjects;
using AutomationTestConsole.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1
{
    public class AmazonPage : BasePage
    {
        StandardMethods standardmethods;

        private string _price1 = string.Empty;
        private string _price2 = string.Empty;
        private string _price3 = string.Empty;

        public string Price1Value { get => _price1; set => _price1 = value; }
        public string Price2Value { get => _price2; set => _price2 = value; }
        public string Price3Value { get => _price3; set => _price3 = value; }

        public AmazonPage(Browser browser): base (browser)
        {
        }

        #region Element Locators       

        [FindsBy(How = How.Id, Using = "ap_email")]
        private readonly IWebElement _username = null;

        [FindsBy(How = How.Id, Using = "ap_password")]
        private readonly IWebElement _password = null;

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        private readonly IWebElement _loginButton = null;

        [FindsBy(How = How.XPath, Using = "//*[@id='nav-hamburger-menu']/i")]
        private readonly IWebElement _menu = null;

        [FindsBy(How = How.CssSelector, Using = "div#hmenu-customer-name")]
        private readonly IWebElement _identificateButton = null;

        [FindsBy(How = How.Id, Using = "continue")]
        private readonly IWebElement _continueButton = null;

        [FindsBy(How = How.XPath, Using = "//span[@class='nav-line-1' and contains(text(),'Hola Ricardo')]")]
        private readonly IWebElement _welcomeText = null;

        #endregion Element Locators


        #region Search Locators       

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        private readonly IWebElement _inputText = null;

        [FindsBy(How = How.CssSelector, Using = "div.nav-search-submit")]
        private readonly IWebElement _searchButton = null;

        [FindsBy(How = How.XPath, Using = "//div[@data-cel-widget='search_result_0']//img")]
        private readonly IWebElement _firstElement = null;

        [FindsBy(How = How.Id, Using = "submit.add-to-cart")]
        private readonly IWebElement _addToCart = null;

        [FindsBy(How = How.Id, Using = "nav-cart")]
        private readonly IWebElement _goToCart = null;

        [FindsBy(How = How.Id, Using = "nav-cart-count")]
        private readonly IWebElement _ItemsCount = null;

        [FindsBy(How = How.XPath, Using = "//div[@data-cel-widget='search_result_0']//img")]
        private readonly IWebElement _secondElement = null;


        #endregion Serch Locators

        #region Prices 

        [FindsBy(How = How.XPath, Using = "(//span[@class= 'a-price'])[1]")]
        private readonly IWebElement _searchPrice = null;

        [FindsBy(How = How.Id, Using = "priceblock_ourprice")]
        private readonly IWebElement _detailPrice = null;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class, 'sc-product-price')])[1]")]
        private readonly IWebElement _cartPrice = null;

        #endregion Prices

        #region data access

        public IWebElement InputUsername => _username;

        public IWebElement InputPassword => _password;

        public IWebElement LoginButton => _loginButton;

        public IWebElement Menu => _menu;

        public IWebElement IdentificateButton => _identificateButton;

        public IWebElement ContinueButton => _continueButton;

        public IWebElement WelcomeText => _welcomeText;

        public IWebElement SearchButton => _searchButton;

        public IWebElement SearchBox => _inputText;

        public IWebElement FirstElement => _firstElement;

        public IWebElement SearchPrice => _searchPrice;

        public IWebElement DetailPrice => _detailPrice;

        public IWebElement CartPrice => _cartPrice;

        public IWebElement ButtonAddToCart => _addToCart;

        public IWebElement GoToCart => _goToCart;

        public IWebElement ItemsCount => _ItemsCount;

        public IWebElement SecondElement => _secondElement;

        #endregion

        public AmazonPage GoTo()
        {
            string url = Parameters.Url;

            Browser.GoTo(url);
            InitElements();
            return this;
        }

        public AmazonPage LoginWithCredentials(string username = null, string password = null )
        {
            standardmethods = new StandardMethods(Browser);
            //?? --> agarra el recibido (username) como parametro
            //en caso de ser nulo (no se recibió) agarra el de la clase 'Parameters'
            string loginUsername = username ?? Parameters.User;
            string loginPassword = password ?? Parameters.Password;

            standardmethods
                .Click(Menu, "Menu[button]")
                .Click(IdentificateButton, "Identificate[button]")
                .EnterText(InputUsername, loginUsername, "Username[input]")
                .Click(ContinueButton, "Continue[button]")
                .EnterText(InputPassword, loginPassword, "Password[input]")
                .Click(LoginButton, "Login[button]")
                .ElementPresent(WelcomeText, "Welcome[Text]");

            return this;
        }

        public AmazonPage SearchProduct(string item)
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .EnterText(SearchBox, item, "Search Box")
                .Click(SearchButton, "Search[button]")
                .ElementPresent(SearchPrice, "precio");

            Price1Value = SearchPrice.Text.Replace("\r\n", ".");

            return this;
        }

        //not being used
        public AmazonPage SelectProduct(int index)
        {
            index = index - 1;
            standardmethods = new StandardMethods(Browser);
            IWebElement searchResultIndex = standardmethods
                .ReturnElement(By.XPath("//div[@data-cel-widget='search_result_" +  index + "']//img"),
                                "Search result " + index);

            standardmethods
                .Click(searchResultIndex, "Item #" + index);
            standardmethods.ElementPresent(DetailPrice, "precio");

            Price2Value = DetailPrice.Text;
            return this;
        }

        public AmazonPage SelectFirstProduct()
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .Click(FirstElement, "FirstItem");

            standardmethods
                .ElementPresent(DetailPrice, "precio");

            Price2Value = DetailPrice.Text;
            return this;
        }

        public AmazonPage AddToCart()
        {
            standardmethods = new StandardMethods(Browser);
            standardmethods.Click(ButtonAddToCart, "Element");
            return this;
        }

        public AmazonPage OpenCart()
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .Click(GoToCart, "Element")
                .ElementPresent(CartPrice, "price");

            Price3Value = CartPrice.Text;
            return this;
        }


        public AmazonPage ComparePrices1vs2()
        {
            Log.AssertAreEqual(Price1Value, Price2Value, "1 vs 2 is wronng");
            return this;
        }

        public AmazonPage ComparePrices1vs3()
        {
            Log.AssertAreEqual(Price1Value, Price3Value, "1 vs 3 is wronng");
            return this;
        }

        public AmazonPage CardItemsCount(int expectedCount)
        {
            Log.AssertAreEqual(expectedCount, Convert.ToInt32(ItemsCount.Text), "Item validation");

            return this;

        }

        public AmazonPage SearchSecondProduct(string item)
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .EnterText(SearchBox, item, "Search Box")
                .Click(SearchButton, "Search[button]")
                .ElementPresent(SearchPrice, "precio");

            Price1Value = SearchPrice.Text.Replace("\r\n", ".");

            return this;
        }

        public AmazonPage SelectSecondProduct()
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .Click(SecondElement, "SecondItem");

            standardmethods
                .ElementPresent(DetailPrice, "price");

            Price2Value = DetailPrice.Text;
            return this;
        }
    }
}
