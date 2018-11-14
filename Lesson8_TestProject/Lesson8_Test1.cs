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

namespace Lesson8_TestProject
{
    [TestFixture]
    public class Lesson8_Test1 : TestBase
    {
        List<IWebElement> NewWindowLinks()
        {
            return driver.FindElements(By.CssSelector("#content i.fa-external-link")).ToList();
        }

        IWebElement NewCountryButton()
        {
            return driver.FindElement(By.CssSelector("#content a.button[href*=edit_country]"));
        }

        void OpenNewWindowSwitchToAndClose(IWebElement linkToNewWindow)
        {
            string currentWindow = driver.CurrentWindowHandle;
            linkToNewWindow.Click();
            string newWindow = wait.Until(d => { return driver.WindowHandles.First(x => !x.Contains(currentWindow));});
            driver.SwitchTo().Window(newWindow);
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
        }

        [Test]
        public void Test()
        {
            driver.Url = countriesUrl;
            AdminLogin();
            NewCountryButton().Click();
            for(int i = 0; i < NewWindowLinks().Count; i++)
            {
                OpenNewWindowSwitchToAndClose(NewWindowLinks()[i]);
            }
        }
    }
}
