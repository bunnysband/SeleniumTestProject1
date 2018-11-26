using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lesson11_TestProject.Pages
{
    public class CartBlock : Page
    {
        const string checkoutLinkLocator = "#cart a.link";
        const string quantityOfProductLocator = "#cart a.content .quantity";
        public CartBlock(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = quantityOfProductLocator)]
        IWebElement quantityOfProduct;

        [FindsBy(How = How.CssSelector, Using = checkoutLinkLocator)]
        IWebElement checkoutLink;

        public void CheckProductCountInCart(int productNumber)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(quantityOfProduct, productNumber.ToString()));
        }

        public void Checkout()
        {
            checkoutLink.Click();
        }
    }
}
