using Automation1.Logger;
using Automation1.PageObjects;
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
    public class FacebookPage : BasePage
    {
        StandardMethods standardmethods;
    
        public FacebookPage(Browser browser): base (browser)
        {
        }

        #region Element Locators
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'rápido') and contains(text(),'fácil')]")]
        private readonly IWebElement _staticMessage = null;

        [FindsBy(How = How.Name, Using = "firstname")]
        private readonly IWebElement _inputFirstname = null;

        [FindsBy(How = How.Name, Using = "lastname")]
        private readonly IWebElement _inputLastname = null;

        [FindsBy(How = How.Name, Using = "reg_email__")]
        private readonly IWebElement _inputPhonenumber = null;

        #endregion Element Locators

        #region data access

        public IWebElement StaticMessage => _staticMessage;

        public IWebElement InputFirstname => _inputFirstname;

        public IWebElement InputLastname => _inputLastname;

        public IWebElement InputPhonenumber => _inputPhonenumber;

        #endregion

        public FacebookPage GoTo()
        {
            //Browser.GoTo("https://es-la.facebook.com/");
            Browser.GoTo("https://es-la.facebook.com/");
            InitElements();
            return this;
        }


        public FacebookPage ValidateMessage(string expectedmessage)
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .ElementPresent(StaticMessage, "Welcome to Facebook [Text]");
             
            Log.AssertAreEqual(expectedmessage, StaticMessage.Text, "Message Validation");
            return this;
        }
        public FacebookPage FillInformation(string firstName, string lastName, string PhoneNumber)
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .EnterText(InputFirstname, firstName, "FirstName [Input]")
                .EnterText(InputLastname, lastName, "LastName [Input]")
                .EnterText(InputPhonenumber, PhoneNumber, "PhoneNumber [Input]");

            return this;
        }
    }
}
