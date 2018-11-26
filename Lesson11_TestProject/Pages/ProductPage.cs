using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lesson11_TestProject.Pages
{
    public class ProductPage: Page
    {
        const string addToCartButtonLocator = "button[name = add_cart_product]";
        public ProductPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = addToCartButtonLocator)]
        IWebElement addToCartButton;

        public void AddProductToCart()
        {
            addToCartButton.Click();
        }
    }
}
