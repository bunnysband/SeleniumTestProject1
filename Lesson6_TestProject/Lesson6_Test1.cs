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

namespace Lesson6_TestProject
{
    [TestFixture]
    public class Lesson6_Test1 : TestBase
    {
        IWebElement LoginForm()
        {
            return driver.FindElement(By.CssSelector("form[name=login_form]"));
        }

        IWebElement CustomerForm()
        {
            return driver.FindElement(By.CssSelector("form[name=customer_form]"));
        }

        void Logout()
        {
            driver.FindElement(By.CssSelector("#box-account a[href*=logout]")).Click();
        }

        void Login(string email)
        {
            LoginForm().FindElement(By.CssSelector("input[name=email]")).SendKeys(email);
            LoginForm().FindElement(By.CssSelector("input[name=password]")).SendKeys("password");
            LoginForm().FindElement(By.CssSelector("button[name=login]")).Click();
        }

        void CustomerRegistration(string email)
        {
            var random = new Random();
            LoginForm().FindElement(By.TagName("a")).Click();
            CustomerForm().FindElement(By.Name("firstname")).SendKeys("FirstName");
            CustomerForm().FindElement(By.Name("lastname")).SendKeys("LastName");
            CustomerForm().FindElement(By.Name("address1")).SendKeys("Address1");
            CustomerForm().FindElement(By.Name("postcode")).SendKeys(random.Next(10000, 99999).ToString());
            CustomerForm().FindElement(By.Name("city")).SendKeys("City");
            var country = new SelectElement(CustomerForm().FindElement(By.CssSelector("select[name=country_code]")));
            country.SelectByText("United States");
            CustomerForm().FindElement(By.Name("email")).SendKeys(email);
            CustomerForm().FindElement(By.Name("phone")).SendKeys("+1" + random.Next(100000000).ToString());
            CustomerForm().FindElement(By.Name("password")).SendKeys("password");
            CustomerForm().FindElement(By.Name("confirmed_password")).SendKeys("password");
            CustomerForm().FindElement(By.CssSelector("button[name=create_account]")).Click();
        }

        [Test]
        public void Test()
        {
            string email = $"email{new Random().Next(1000)}@email.com"; 
            LoadMainPage();
            CustomerRegistration(email);
            Logout();
            Login(email);
            Logout();
        }
    }
}
