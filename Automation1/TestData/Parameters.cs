using Automation1.Helpers.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestConsole.TestData
{
    public class Parameters
    {
        private static XMLReader MyReader;

        private static string _url = string.Empty;
        private static string _user = string.Empty;
        private static string _password = string.Empty;

        public static string Url { get => _url; set => _url = value; }
        public static string User { get => _user; set => _user = value; }
        public static string Password { get => _password; set => _password = value; }

        /*
        Url = "https://www.amazon.com.mx/";
        User = "eneida.montserrat@gmail.com";
        Password ="Converse1";  */

        public static void SetParameters()
        {
            MyReader = new XMLReader();

            Url = MyReader.GetConfigValue("applicationUrl");
        }

        public static void SetCredentials()
        {
            MyReader = new XMLReader();

            User = MyReader.GetConfigValue("username");
            Password = MyReader.GetConfigValue("password");
        }
    }
}
