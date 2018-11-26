using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;
using Lesson11_TestProject.Applications;

namespace Lesson11_TestProject.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected Litecart litecart;

        [SetUp]
        protected void Start()
        {
            driver = new ChromeDriver();
            litecart = new Litecart(driver);
        }

        [TearDown]
        protected void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
