using Automation1;
using Automation1.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Pages
    {
        private Browser Browser { get; set; }

        public Pages(Browser Browser)
        {
            this.Browser = Browser;
        }

        private AmazonPage _amazonPage;
        public AmazonPage AmazonPage
        {
            get { return _amazonPage ?? (_amazonPage = new AmazonPage(Browser)); }
        }

        private StandardMethods _standardMethods;
        public StandardMethods StandardMethods
        {
            get { return _standardMethods ?? (_standardMethods = new StandardMethods(Browser)); }
        }
    }
}
