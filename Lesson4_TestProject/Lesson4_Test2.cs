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

namespace Lesson4_TestProject
{
    [TestFixture]
    public class Lesson4_Test2: TestBase
    {
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
