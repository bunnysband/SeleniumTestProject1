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
            string regularPriceOnMainPageFontSize = GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("font-size");
            string regularPriceOnMainPageFontColor = GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("color");
            string regularPriceOnMainPageFontStyle = GetProductOnMainPageAttribute(regularPriceCssSelector).GetCssValue("text-decoration-line");
            string campaignPriceOnMainPageFontSize = GetProductOnMainPageAttribute(campaignPriceCssSelector).GetCssValue("font-size");
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

            regularPriceOnMainPageFontSize = Regex.Match(regularPriceOnMainPageFontSize, @"[0-9.,]{1,}").Value;
            campaignPriceOnMainPageFontSize = Regex.Match(campaignPriceOnMainPageFontSize, @"[0-9.,]{1,}").Value;
            regularPriceOnProductPageFontSize = Regex.Match(regularPriceOnMainPageFontSize, @"[0-9.,]{1,}").Value;
            campaignPriceOnProductPageFontSize = Regex.Match(campaignPriceOnMainPageFontSize, @"[0-9.,]{1,}").Value;
            var regColorOnMain = Regex.Matches(regularPriceOnMainPageFontColor, @"\d{1,}").OfType<Match>().Select(x => Convert.ToInt32(x.Value)).Take(3).ToArray();
            var campColorOnMain = Regex.Matches(campaignPriceOnMainPageFontColor, @"\d{1,}").OfType<Match>().Select(x => Convert.ToInt32(x.Value)).Take(3).ToArray();
            var regColorOnProduct = Regex.Matches(regularPriceOnProductPageFontColor, @"\d{1,}").OfType<Match>().Select(x => Convert.ToInt32(x.Value)).Take(3).ToArray();
            var campColorOnProduct = Regex.Matches(campaignPriceOnProductPageFontColor, @"\d{1,}").OfType<Match>().Select(x => Convert.ToInt32(x.Value)).Take(3).ToArray();
           
            Assert.AreEqual(productNameOnMainPage, productNameOnProductPage);
            Assert.AreEqual(regularPriceOnMainPage, regularPriceOnProductPage);
            Assert.AreEqual(campaignPriceOnMainPage, campaignPriceOnProductPage);
            Assert.AreEqual(regularPriceOnMainPageFontStyle, "line-through");
            Assert.AreEqual(regColorOnMain[0], regColorOnMain[1]);
            Assert.AreEqual(regColorOnMain[0], regColorOnMain[2]);
            Assert.AreEqual(campaignPriceOnMainPageFontStyle, "700");
            Assert.AreEqual(campColorOnMain[1], 0);
            Assert.AreEqual(campColorOnMain[2], 0);
            Assert.AreEqual(regularPriceOnProductPageFontStyle, "line-through");
            Assert.AreEqual(regColorOnProduct[0], regColorOnProduct[1]);
            Assert.AreEqual(regColorOnProduct[0], regColorOnProduct[2]);
            Assert.AreEqual(campaignPriceOnProductPageFontStyle, "700");
            Assert.AreEqual(campColorOnProduct[1], 0);
            Assert.AreEqual(campColorOnProduct[2], 0);
            Assert.Greater(campaignPriceOnMainPageFontSize, regularPriceOnMainPageFontSize);
            Assert.Greater(campaignPriceOnProductPageFontSize, regularPriceOnProductPageFontSize);
        }
    }
}
