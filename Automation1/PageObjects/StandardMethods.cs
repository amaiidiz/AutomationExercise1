using Automation1.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1.PageObjects
{
    public class StandardMethods : BasePage
    {
        private bool useExplictWaits = false;
        private WebDriverWait wait;

        public bool UseExplictWaits { get => useExplictWaits; set => useExplictWaits = value; }

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

            if (!UseExplictWaits)
            {
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
            }
            else
            {
                try
                {
                    wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10 * WaitFactor));
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    Log.Info("Element is present using explicit waits: " + elementDesc);
                }
                catch(WebDriverTimeoutException)
                {
                    Log.AssertFail("Element is NOT present using explicit waits: " + elementDesc);
                }
                
            }
            return this;
        }

        public StandardMethods Click(IWebElement element, string elementDesc, int WaitFactor = 1)
        {
            if (!UseExplictWaits)
            {
                ElementPresent(element, elementDesc, WaitFactor);
                element.Click();
                Log.Info("Clicked: " + elementDesc);
            }
            else
            {
                try
                {
                    wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10 * WaitFactor));
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    element.Click();
                    Log.Info("Clicked using explicit waits: " + elementDesc);
                }
                catch(WebDriverTimeoutException)
                {
                    Log.AssertFail("Could NOT Click using explicit waits: " + elementDesc);
                }                
            }
                
            return this;
        }

        public StandardMethods EnterText(IWebElement element, string text, string elementDesc = "element", int WaitFactor = 1)
        {
            ElementPresent(element, elementDesc, WaitFactor);
            element.SendKeys(text);
            Log.Info("Text Entered: '" + text + "' into : " + elementDesc);
            return this;
        }

        public IWebElement ReturnElement(By by, string elementDesc, int WaitFactor = 1)
        {
            IWebElement element = null;
            bool isDisplayed = false;
            int counter = 1;

            if (!UseExplictWaits)
            {
                while (!isDisplayed && counter <= 10)
                {
                    try
                    {
                        // By Default will wait 1 sec each iteration
                        Wait(WaitFactor * 1000);
                        element = Browser.FindElement(by);
                        isDisplayed = element.Displayed;
                        Log.Info("Element was found: " + elementDesc);
                    }
                    catch (NoSuchElementException)
                    {

                    }
                    counter++;
                }
                if (!isDisplayed)
                {
                    Log.AssertFail("Element was not found: " + elementDesc);
                }
            }
            else
            {
                try
                {
                    wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10 * WaitFactor));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                    Log.Info("Element was found using Explicit waits: " + elementDesc);
                }
                catch(WebDriverTimeoutException)
                {
                    Log.AssertFail("Element was NOT found using Explicit waits: " + elementDesc);
                }                
            }        

            return element;
        }
    }
}
