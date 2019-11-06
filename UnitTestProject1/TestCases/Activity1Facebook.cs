using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1.Logger;

namespace UnitTestProject1
{

    [TestClass]
    public class Activity1Facebook : EneidaTest
    {
        [TestInitialize] 
        public void BeforeEachTest()
        {
            InitializeFramework();
            Pages.FacebookPage.InitElements();
        }        

        [TestCategory("SocialMedia"), Priority(1), TestMethod]
        public void FB_ValidateMsg_EnterInfo()
        {
            Pages.FacebookPage
                .GoTo()
                .ValidateMessage("Es rápido y fácil.")
                .FillInformation("eneida", "sanchez", "3344556677");

            Pages.StandardMethods
                 .Wait(2000);

            Log.Info("All validation passed");
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            CleanUpTest();
        }
    }
}
