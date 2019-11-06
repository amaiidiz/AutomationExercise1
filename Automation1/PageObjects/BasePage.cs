//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1
{
    public abstract class BasePage
    {
        public Browser Browser { get; set; }

        protected BasePage() { }

        protected BasePage(Browser browser)
        {
            this.Browser = browser;
        }        
        
        public void InitElements()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }
    }
}
