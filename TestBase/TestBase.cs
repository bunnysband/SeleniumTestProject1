﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TestBase
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        string userName = "admin";
        string passWord = "admin";
        string mainPageUrl = "http://localhost/litecart";

        protected void LoginAdmin()
        {
            driver.Url = $"{mainPageUrl}/admin/";
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
    }
}
