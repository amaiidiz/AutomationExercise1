using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1;

namespace AutomationTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string activityId = "2";

            switch(activityId)
            {
                case "1":
                    Activity1Facebook mytest = new Activity1Facebook();
                    mytest.StartAsConsoleApp = true;

                    mytest.BeforeEachTest();
                    mytest.FB_ValidateMsg_EnterInfo();
                    mytest.CleanUpTest();
                    break;

                case "2":
                    Activity2Facebook mytest2 = new Activity2Facebook();
                    mytest2.StartAsConsoleApp = true;

                    mytest2.BeforeEachTest();
                    mytest2.FB_BirthdayDropdownTest();
                    mytest2.CleanUpTest();
                    break;

                default:
                    throw new NotImplementedException();

            }            
        }
    }
}
