using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TestBase;
using System.Linq;
using System.Collections.Generic;

namespace Lesson4_TestProject
{
    [TestFixture]
    public class Lesson4_Test1: TestBase.TestBase
    {
        List<IWebElement> FindParents()
        {
            return driver.FindElements(By.CssSelector("li[id^=app] > a")).ToList();
        }

        List<IWebElement> FindChildren()
        {
            return driver.FindElements(By.CssSelector("li[id^=doc] > a")).ToList();
        }

        void CheckTitle()
        {
            driver.FindElement(By.CssSelector("#content h1"));
        }

        [Test]
        public void Test()
        {
            LoginAdmin();
            for (int i = 0; i < FindParents().Count; i++)
            {
                FindParents()[i].Click();
                CheckTitle();
                for (int j = 0; j < FindChildren().Count; j++)
                {
                    FindChildren()[j].Click();
                    CheckTitle();
                }
            }
        }
    }
}
