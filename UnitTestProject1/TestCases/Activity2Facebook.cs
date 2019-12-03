using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation1.Logger;

namespace UnitTestProject1
{   
    [TestClass]
    public class Activity2Facebook : EneidaTest
    {
        private bool startAsConsoleApp = false;

        public bool StartAsConsoleApp { get => startAsConsoleApp; set => startAsConsoleApp = value; }

        [TestInitialize] 
        public void BeforeEachTest()
        {
            InitializeFramework(StartAsConsoleApp);
            Pages.FacebookPage.InitElements();
        }        

        [TestCategory("SocialMedia"), Priority(1), TestMethod]
        public void FB_BirthdayDropdownTest()
        {
            Pages.FacebookPage
                .GoTo("https://www.facebook.com/")
                //.ValidateTitle("Facebook - Log In or Sign Up")
                .ValidateTitle("Facebook - Inicia sesión o regístrate")
                .SelectBirthday(1992, 12, 19)
                .SelectGender("F")
                .ValidateLeftMessage("Facebook te ayuda a comunicarte y compartir con las personas que forman parte de tu vida.");

            Pages.StandardMethods
                 .Wait(3000);

            Log.Info("All validations passed :)");
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            CleanUpTest();
        }
    }
}