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

namespace Lesson7_TestProject
{
    [TestFixture]
    public class Lesson7_Test1 : TestBase
    {
        IWebElement AddToCartButton()
        {
            return driver.FindElement(By.CssSelector("button[name=add_cart_product]"));
        }

        IWebElement QuantityOfProductInBasket()
        {
            return driver.FindElement(By.CssSelector("#cart a.content .quantity"));
        }

        IWebElement CheckoutHref()
        {
            return driver.FindElement(By.CssSelector("#cart a.link"));
        }

        IWebElement RemoveButton()
        {
            return driver.FindElements(By.CssSelector("button[name=remove_cart_item]")).FirstOrDefault();
        }

        IWebElement TableWithProducts()
        {
            return driver.FindElement(By.CssSelector("#box-checkout-summary table"));
        }

        [Test]
        public void Test()
        {
            for (int i = 1; i <= 3; i++)
            {
                LoadMainPage();
                FindProducts().First().Click();
                AddToCartButton().Click();
                wait.Until(ExpectedConditions.TextToBePresentInElement(QuantityOfProductInBasket(), i.ToString()));
            }
            CheckoutHref().Click();
            while(RemoveButton() != null)
            {
                var table = TableWithProducts();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[name=remove_cart_item]"))).Click();
                wait.Until(ExpectedConditions.StalenessOf(table));
            }
        }
    }
}
