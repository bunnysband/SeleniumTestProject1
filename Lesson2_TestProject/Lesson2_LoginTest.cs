using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TestProject2
{
    [TestFixture]
    public class Lesson2_LoginTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        string userName = "admin";
        string passWord = "admin";
        string adminLoginUrl = "http://localhost/litecart/admin/";

        [SetUp]
        public void Start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginTest()
        {
            driver.Url = adminLoginUrl;
            driver.FindElement(By.Name("username")).SendKeys(userName);
            driver.FindElement(By.Name("password")).SendKeys(passWord);
            driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
