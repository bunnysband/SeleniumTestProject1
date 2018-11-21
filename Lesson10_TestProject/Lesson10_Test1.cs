using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumTestBase;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lesson10_TestProject
{
    [TestFixture]
    public class Lesson10_Test1 : TestBase
    {
        [Test]
        public void Test()
        {
            driver.Url = catalogUrl;
            AdminLogin();
            for (int i = 0; i < ProductRows().Count; i++)
            {
                try
                {
                    ProductRows()[i].FindElement(By.CssSelector("a[href*=edit_product]")).Click();
                }
                catch(NoSuchElementException) { continue; }
                var logs = driver.Manage().Logs.GetLog("browser");
                CollectionAssert.IsEmpty(logs);
                driver.Navigate().Back();
            }
        }
    }
}
