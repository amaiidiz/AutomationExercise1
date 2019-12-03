using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation1.Logger
{
    public static class Log
    {
        private static DateTime date;

        public static void Info(string message)
        {
            date =  DateTime.Now;
            string timestamp = date.ToString("yyyy-MM-dd hh:mm:ss tt");
            Console.WriteLine("["+timestamp+"]: " + message);
        }

        public static void InfoBold(string messageHighlighted)
        {
            Info("<b>" + messageHighlighted + "</b>");
        }

        public static void Pass()
        {
            throw new NotImplementedException();
        }

        public static void Fail()
        {
            throw new NotImplementedException();
        }

        public static void AssertAreEqual(string expectedText, string actualText, string validationmessage)
        {
            Assert.AreEqual(expectedText, actualText, validationmessage);
            Info("AssertAreEqual passed: [" + expectedText + "] vs [" + actualText + "] " + validationmessage);
        }

        public static void AssertAreEqual(int expected, int actual, string validationmessage)
        {
            Assert.AreEqual(expected, actual, validationmessage);
            Info("AssertAreEqual passed: [" + expected + "] vs [" + actual + "] " + validationmessage);
        }

        public static void AssertAreNotEqual(string expected, string actual, string validationmessage)
        {
            Assert.AreNotEqual(expected, actual, validationmessage);
            Info("AssertAreNotEqual passed: [" + expected + "] vs [" + actual + "] " + validationmessage);
        }

        public static void AssertAreNotEqual(int expected, int actual, string validationmessage)
        {
            Assert.AreNotEqual(expected, actual, validationmessage);
            Info("AssertAreNotEqual passed: [" + expected + "] vs [" + actual + "] " + validationmessage);
        }

        public static void AssertIsTrue(bool condition, string validationMessage)
        {
            Assert.IsTrue(condition, validationMessage);
            Info("AssertIsTrue passed: " + validationMessage);
        }

        public static void AssertIsFalse(bool condition, string validationMessage)
        {
            Assert.IsFalse(condition, validationMessage);
            Info("AssertIsFalse passed: " + validationMessage);
        }

        public static void AssertFail(string message)
        {
            Assert.Fail(message);
        }

        public static void AssertInconclusive(string message)
        {
            Assert.Inconclusive(message);
        }
    }
}
