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

        [FindsBy(How = How.Name, Using = "birthday_month")]
        private readonly IWebElement _ddlMonth = null;

        [FindsBy(How = How.Name, Using = "birthday_day")]
        private readonly IWebElement _ddlDay = null;

        [FindsBy(How = How.Name, Using = "birthday_year")]
        private readonly IWebElement _ddlYear = null;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'comunicarte') and contains(text(),'vida')]")]
        private readonly IWebElement _staticMessage2 = null;

        #endregion Element Locators

        #region data access

        public IWebElement StaticMessage => _staticMessage;

        public IWebElement InputFirstname => _inputFirstname;

        public IWebElement InputLastname => _inputLastname;

        public IWebElement InputPhonenumber => _inputPhonenumber;

        public IWebElement StaticMessage2 => _staticMessage2;



        #endregion

        public FacebookPage GoTo(string url = "https://es-la.facebook.com/")
        {
            Browser.GoTo(url);
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

        public FacebookPage ValidateTitle(string expectedTitle)
        {
            Log.AssertAreEqual(expectedTitle, PageTitle, "Page title validation");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public FacebookPage SelectBirthday(int year, int month, int day)
        {
            standardmethods = new StandardMethods(Browser);

            bool useStandardMethods = true;
            IWebElement ddlOptionYear = null;
            IWebElement ddlOptionMonth = null;
            IWebElement ddlOptionDay = null;

            Log.AssertIsTrue(month >= 1 && month <= 12, "Month Validation from 1 to 12");
            Log.AssertIsTrue(day >= 1 && day <= 31, "Day Validation from 1 to 31");
            Log.AssertIsTrue(year >= 1905 && year <= 2019, "Year Validation from 1905 to 2019");

            standardmethods
                .ElementPresent(_ddlYear, "Year [Dropdown]")
                .ElementPresent(_ddlMonth, "Month [Dropdown]")
                .ElementPresent(_ddlDay, "Day [Dropdown]");

            if (useStandardMethods)
            {
                ddlOptionYear = standardmethods.ReturnElement(By.XPath("//*[@id='year']//option[@value = '" + year + "']"), "Year [Option]");
                ddlOptionMonth = standardmethods.ReturnElement(By.XPath("//*[@id='month']//option[@value = '" + month + "']"), "Month [Option]");
                ddlOptionDay = standardmethods.ReturnElement(By.XPath("//*[@id='day']//option[@value = '" + day + "']"), "Day [Option]");

                Log.Info("");
                Log.Info("Used ReturnElement");
                Log.Info("");
            }
            else
            {
                ddlOptionYear = _ddlYear.FindElement(By.XPath(".//option[@value = '" + year + "']"));
                ddlOptionMonth = _ddlMonth.FindElement(By.XPath(".//option[@value = '" + month + "']"));
                ddlOptionDay = _ddlDay.FindElement(By.XPath(".//option[@value = '" + day + "']"));

                Log.Info("");
                Log.Info("Used FindElement");
                Log.Info("");
            }

            standardmethods
                .Click(_ddlYear, "Year [DDL]")
                .Click(ddlOptionYear, "DDL Year [Option]")
                .Click(_ddlMonth, "Month [DDL]")
                .Click(ddlOptionMonth, "DDL Month [Option]")
                .Click(_ddlDay, "Day [DDL]")
                .Click(ddlOptionDay, "DDL Day [Option]");            

            Log.Info("");
            Log.Info("Selected birthday successfully");
            Log.Info("");

            return this;
        }

        public FacebookPage SelectGender(string gender)
        {
            standardmethods = new StandardMethods(Browser);
            IWebElement radioButton = null;
            string description = string.Empty;
            gender = gender.ToUpper().Trim();

            switch (gender)
            {
                case "FEMALE":
                case "F":
                    radioButton = standardmethods.ReturnElement(By.XPath("//input[@value='1']"), "Female [Radiobutton]");
                    description = "Female";
                    break;
                case "MALE":
                case "M":
                    radioButton = standardmethods.ReturnElement(By.XPath("//input[@value='2']"), "Male [Radiobutton]");
                    description = "Male";
                    break;
                case "CUSTOM":
                case "C":
                    radioButton = standardmethods.ReturnElement(By.XPath("//input[@value='-1']"), "Custom [Radiobutton]");
                    description = "Custom";
                    break;
                default:
                    Log.AssertInconclusive("Incorrect user input");
                    break;
            }

            standardmethods.Click(radioButton, description);
            return this;
        }

        public FacebookPage ValidateLeftMessage(string expectedmessage)
        {
            standardmethods = new StandardMethods(Browser);

            standardmethods
                .ElementPresent(StaticMessage2, "Connect with friends and the world around you on Facebook. [Text]");

            Log.AssertAreEqual(expectedmessage, StaticMessage2.Text, "Message Validation");
            return this;
        }

    }
}
