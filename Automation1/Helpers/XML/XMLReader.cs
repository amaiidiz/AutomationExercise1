using Automation1.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Automation1.Helpers.XML
{
    public class XMLReader
    {
        public string GetConfigValue(string fieldWanted)
        {
            string basePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string filePath = basePath + "\\ConfigFiles\\ConfigParameters.xml";
            string fieldValue = string.Empty;
            List<string> allowedFields = new List<string>
            {
                "applicationUrl",
                "username",
                "password"
            };

            Log.AssertIsTrue(allowedFields.Exists(x => x == fieldWanted), "Invalid field");
            System.Console.WriteLine("VALIDATION PASSED! " + fieldWanted + " is a valid Field!");

            XElement xelement = XElement.Load(filePath);
            var configValues = xelement.Elements(fieldWanted).FirstOrDefault();
            fieldValue = configValues.Value;

            Log.AssertIsFalse(string.IsNullOrEmpty(fieldValue), fieldWanted + " was not found");
            Log.Info(fieldWanted + " is: " + fieldValue);

            return fieldValue;
        }
    }

}