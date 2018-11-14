using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;

namespace SeleniumTestBase
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected const string countriesUrl = "http://localhost/litecart/admin/?app=countries&doc=countries";
        protected const string geoZonezUrl = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
        string userName = "admin";
        string passWord = "admin";
        string mainPageUrl = "http://localhost/litecart";

        protected void LoadAdminPageAndLogin()
        {
            driver.Url = $"{mainPageUrl}/admin/";
            AdminLogin();
        }

        protected void AdminLogin()
        {
            driver.FindElement(By.Name("username")).SendKeys(userName);
            driver.FindElement(By.Name("password")).SendKeys(passWord);
            driver.FindElement(By.Name("login")).Click();
        }

        protected void LoadMainPage()
        {
            driver.Url = mainPageUrl;
        }

        [SetUp]
        protected void Start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        protected void Stop()
        {
            driver.Quit();
            driver = null;
        }

        protected List<IWebElement> FindProducts()
        {
            return driver.FindElements(By.CssSelector("#main ul.listing-wrapper.products .product.column.shadow")).ToList();
        }
    }
}
