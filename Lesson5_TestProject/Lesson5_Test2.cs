using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumTestBase;
using System.Linq;
using System.Collections.Generic;

namespace Lesson5_TestProject
{
    [TestFixture]
    public class Lesson5_Test2 : TestBase
    {
        IWebElement GetFirtstProductFromCamapaigns()
        {
            return driver.FindElement(By.CssSelector("#box-campaigns li.product.column"));
        }

        [Test]
        public void Test1()
        {
            LoadMainPage();
            string productNameOnMainPage = GetFirtstProductFromCamapaigns().FindElement(By.CssSelector("div.name")).Text;
            string regularPriceOnMainPage = GetFirtstProductFromCamapaigns().FindElement(By.CssSelector("s.regular-price")).Text;
            string campaignPriceOnMainPage = GetFirtstProductFromCamapaigns().FindElement(By.CssSelector("s.campaign-price")).Text;

            GetFirtstProductFromCamapaigns().Click();


        }
    }
}
