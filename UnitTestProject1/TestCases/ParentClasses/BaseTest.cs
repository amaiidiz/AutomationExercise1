using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1;

namespace UnitTestProject1
{
    [TestClass]
    public abstract class BaseTest
    {
        protected Browser Browser { get; set; }

        protected BaseTest ()
        {
            Browser = new Browser();
        }

        public void InitializeBrowser(bool startAsConsoleApp = false)
        {
            string selection = string.Empty;

            if(startAsConsoleApp)
            {
                Console.WriteLine("*****Activity 1*****");
                Console.WriteLine("Select the browser you want to run this test: 1 Chrome, 2 Firefox");
                Console.WriteLine("Enter the number:");
                selection = Console.ReadLine();
            }
            else
            {
                selection = "1";
            }            

            Browser.PickDriver(selection);
        }     
        
        public void CleanUpTest()
        {
            Browser.Quit();
        }
    }
}
