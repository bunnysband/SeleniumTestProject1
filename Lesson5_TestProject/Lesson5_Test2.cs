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
using System.Text.RegularExpressions;

namespace Lesson5_TestProject
{
    [TestFixture]
    public class Lesson5_Test2 : TestBase
    {
        string regularPriceCssSelector = "s.regular-price";
        string campaignPriceCssSelector = "strong.campaign-price";

        IWebElement GetFirtstProductFromCamapaigns()
        {
            return driver.FindElement(By.CssSelector("#box-campaigns li.product.column"));
        }

        IWebElement GetProductOnMainPageAttribute(string cssSelector)
        {
            return GetFirtstProductFromCamapaigns().FindElement(By.CssSelector(cssSelector));
        }

        IWebElement GetProductFromItsPage()
        {
            return driver.FindElement(By.CssSelector("#box-product"));
        }

        IWebElement GetProductOnItsPageAttribute(string cssSelector)
        {
            return GetProductFromItsPage().FindElement(By.CssSelector(cssSelector));
        }

        [Test]
        public void Test()
        {
            LoadMainPage();
            string productNameOnMainPage = GetProductOnMainPageAttribute("div.name").Text;
            string regularPriceOnMainPage = GetProductOnMainPageAttribute(regularPriceCssSelector).Text;
            string campaignPriceOnMainPage = GetProductOnMainPageAttribute(campaignPriceCssSelector).Text;
            int regularPriceOnMainPageFontSize = Int32.Parse(Regex.Match(GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("font-size"), "\\d{ 1,}").Value);
            string regularPriceOnMainPageFontColor = GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("color");
            int[] regularPriceOnMainPageFontStyle = Regex.Matches(GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("text-decoration-line"), "\\d{ 1,}").OfType<int>().ToArray();
            int campaignPriceOnMainPageFontSize = Int32.Parse(Regex.Match(GetProductOnMainPageAttribute(campaignPriceCssSelector).GetCssValue("font-size"), "\\d{ 1,}").Value);
            string campaignPriceOnMainPageFontColor = GetProductOnMainPageAttribute(campaignPriceCssSelector).GetCssValue("color");
            string campaignPriceOnMainPageFontStyle = GetProductOnMainPageAttribute(campaignPriceCssSelector).GetCssValue("font-weight");

            GetFirtstProductFromCamapaigns().Click();

            string productNameOnProductPage = GetProductOnItsPageAttribute("h1.title").Text;
            string regularPriceOnProductPage = GetProductOnItsPageAttribute(regularPriceCssSelector).Text;
            string campaignPriceOnProductPage = GetProductOnItsPageAttribute(campaignPriceCssSelector).Text;
            string regularPriceOnProductPageFontSize = GetProductOnItsPageAttribute(regularPriceCssSelector).GetCssValue("font-size");
            string regularPriceOnProductPageFontColor = GetProductOnItsPageAttribute(regularPriceCssSelector).GetCssValue("color");
            string regularPriceOnProductPageFontStyle = GetProductOnItsPageAttribute(regularPriceCssSelector).GetCssValue("text-decoration-line");
            string campaignPriceOnProductPageFontSize = GetProductOnItsPageAttribute(campaignPriceCssSelector).GetCssValue("font-size");
            string campaignPriceOnProductPageFontColor = GetProductOnItsPageAttribute(campaignPriceCssSelector).GetCssValue("color");
            string campaignPriceOnProductPageFontStyle = GetProductOnItsPageAttribute(campaignPriceCssSelector).GetCssValue("font-weight");

            Assert.AreEqual(productNameOnMainPage, productNameOnProductPage);
            Assert.AreEqual(regularPriceOnMainPage, regularPriceOnProductPage);
            Assert.AreEqual(campaignPriceOnMainPage, campaignPriceOnProductPage);
        }
    }
}
