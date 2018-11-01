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
    public class Lesson4_Test2: TestBase.TestBase
    {
        List<IWebElement> FindProducts()
        {
            return driver.FindElements(By.CssSelector("li[class='product column shadow hover-light']")).ToList();
        }

        [Test]
        public void Test1()
        {
            LoadMainPage();
            for (int i = 0; i < FindProducts().Count; i++)
            {
                FindProducts()[i].FindElements(By.CssSelector(".sticker")).Single();
            }
        }
    }
}
