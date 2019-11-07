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
            Activity1Facebook mytest = new Activity1Facebook();
            mytest.StartAsConsoleApp = true;

            mytest.BeforeEachTest();
            mytest.FB_ValidateMsg_EnterInfo();
            mytest.CleanUpTest();
        }
    }
}
