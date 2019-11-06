using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1;

namespace UnitTestProject1
{

    public abstract class EneidaTest : BaseTest
    {
        protected Pages Pages;

        protected void InitializePages()
        {
            Pages = new Pages(Browser);
        }

        protected void InitializeFramework()
        {
            InitializeBrowser();
            InitializePages();
        }
    }

}
