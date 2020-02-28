using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1;
using AutomationTestConsole.TestData;

namespace UnitTestProject1
{

    public abstract class EneidaTest : BaseTest
    {
        protected Pages Pages;

        protected void InitializePages()
        {
            Pages = new Pages(Browser);
        }

        protected void InitializeFramework(bool startAsConsoleApp = false)
        {
            InitializeBrowser(startAsConsoleApp);
            InitializePages();
            Parameters.SetParameters();
        }
    }

}
