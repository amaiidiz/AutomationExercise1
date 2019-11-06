using Automation1.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1.PageObjects
{
    public class StandardMethods : BasePage
    {
        public StandardMethods(Browser browser) : base(browser)
        {
        }

        public StandardMethods Wait(int WaitTime = 1000)
        {
            System.Threading.Thread.Sleep(WaitTime);
            return this;
        }

       public StandardMethods ElementPresent( IWebElement element, string elementDesc, int WaitFactor = 1)
        {
            bool isDisplayed = false;
            int counter = 1;

            while (!isDisplayed && counter <= 10)
            {
                try
                { 
                // By Default will wait 1 sec each iteration
                Wait(WaitFactor * 1000);
                isDisplayed = element.Displayed;
                }
                catch (NoSuchElementException)
                {

                }
                counter++;
            }
            Log.AssertIsTrue(isDisplayed, "Element not found:" + elementDesc);
            return this;
        }

        public StandardMethods Click(IWebElement element, string elementDesc, int WaitFactor = 1)
        {
            ElementPresent(element, elementDesc, WaitFactor);
            element.Click();
            Log.Info("Clicked: " + elementDesc);
            return this;
        }

        public StandardMethods EnterText(IWebElement element, string text, string elementDesc = "element", int WaitFactor = 1)
        {
            ElementPresent(element, elementDesc, WaitFactor);
            element.SendKeys(text);
            Log.Info("Text Entered: '" + text + "' into : " + elementDesc);
            return this;
        }



    }
}
