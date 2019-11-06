using Automation1.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1
{
    public class Browser
    {
        internal IWebDriver Driver { get; set; }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebDriver PickDriver(string browserTargetString)
        {

            switch (browserTargetString)
            {
                case "1":
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    return Driver;

                case "2":
                    FirefoxOptions options = new FirefoxOptions();
                    options.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
                    Driver = new FirefoxDriver(options);
                    Driver.Manage().Window.Maximize();
                    return Driver;

                default:
                    Log.AssertInconclusive("Incorrect user selection:" + browserTargetString);
                    break;
            }
            return Driver;
        }

        public void EnterText(IWebElement webElement, string text)
        {
            webElement.SendKeys(text);
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
