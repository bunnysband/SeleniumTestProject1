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
using System.IO;
using System.Threading;

namespace Lesson6_TestProject
{
    [TestFixture]
    public class Lesson6_Test2 : TestBase
    {
        [Test]
        public void Test()
        {
            string productName = $"Product{new Random().Next(500)}";
            LoadAdminPageAndLogin();
            driver.FindElement(By.CssSelector("#box-apps-menu-wrapper li#app- > a[href*=catalog]")).Click();
            AddNewProduct(productName);
            driver.FindElement(By.CssSelector("#box-apps-menu-wrapper li#app- > a[href*=catalog]")).Click();
            FindProductInCatalog(productName);
        }

        IWebElement TabGeneral()
        {
            return driver.FindElement(By.CssSelector("#tab-general"));
        }

        IWebElement TabInformation()
        {
            return driver.FindElement(By.CssSelector("#tab-information"));
        }

        IWebElement TabPrices()
        {
            return driver.FindElement(By.CssSelector("#tab-prices"));
        }
        void AddNewProduct(string productName)
        {
            driver.FindElement(By.CssSelector("#content a.button[href*=edit_product]")).Click();
            FillTabGeneral(productName);
            driver.FindElement(By.CssSelector(".tabs a[href*=tab-information]")).Click();
            Thread.Sleep(1000);
            FillTabInformation();
            driver.FindElement(By.CssSelector(".tabs a[href*=tab-prices]")).Click();
            Thread.Sleep(1000);
            FillTabPrices();
            driver.FindElement(By.CssSelector("#content .button-set button[name=save]")).Click();
        }

        void FillTabInformation()
        {
            var manufacturer = new SelectElement(TabInformation().FindElement(By.CssSelector("select[name=manufacturer_id]")));
            manufacturer.SelectByIndex(0);
            TabInformation().FindElement(By.CssSelector("input[name=keywords]")).SendKeys("Keywords");
            TabInformation().FindElement(By.CssSelector("input[name='short_description[en]']")).SendKeys("Short Description");
            TabInformation().FindElement(By.CssSelector("input[name='short_description[en]']")).SendKeys("Short Description");
            TabInformation().FindElement(By.CssSelector("div.trumbowyg-editor")).SendKeys("Description");
            TabInformation().FindElement(By.CssSelector("input[name='head_title[en]']")).SendKeys("Head Title");
            TabInformation().FindElement(By.CssSelector("input[name='meta_description[en]']")).SendKeys("Meta Description");
        }

        void FillTabPrices()
        {
            TabPrices().FindElement(By.CssSelector("input[name=purchase_price]")).Clear();
            TabPrices().FindElement(By.CssSelector("input[name=purchase_price]")).SendKeys("100");
            var currency = new SelectElement(TabPrices().FindElement(By.CssSelector("select[name=purchase_price_currency_code]")));
            currency.SelectByValue("USD");
        }

        void FillTabGeneral(string productName)
        {
            TabGeneral().FindElement(By.CssSelector("input[name='status'][value='1']")).Click();
            TabGeneral().FindElement(By.CssSelector("input[name='name[en]']")).SendKeys(productName);
            TabGeneral().FindElement(By.CssSelector("input[name=code]")).SendKeys(new Random().Next(500).ToString());
            TabGeneral().FindElements(By.CssSelector("input[name^=product_groups]"))[2].Click();
            TabGeneral().FindElement(By.CssSelector("input[name=quantity]")).Clear();
            TabGeneral().FindElement(By.CssSelector("input[name=quantity]")).SendKeys("2");
            TabGeneral().FindElement(By.CssSelector("input[name=date_valid_from]")).SendKeys(DateTime.Now.ToString("ddMMyyyy"));
            TabGeneral().FindElement(By.CssSelector("input[name=date_valid_to]")).SendKeys(DateTime.Now.AddYears(1).ToString("ddMMyyyy"));
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "newDuck.png");
            TabGeneral().FindElement(By.CssSelector("input[type=file]")).SendKeys(filePath);
        }

        void FindProductInCatalog(string productName)
        {
            List<string> products = new List<string>();
            for(int i = 0; i < ProductRows().Count; i++)
            {
                products.Add(ProductRows()[i].FindElement(By.CssSelector("a")).Text);
            }
            CollectionAssert.Contains(products, productName);

        }

        List<IWebElement> ProductRows()
        {
            return driver.FindElements(By.CssSelector("form[name=catalog_form] table tr.row")).ToList();
        }

    }
}
