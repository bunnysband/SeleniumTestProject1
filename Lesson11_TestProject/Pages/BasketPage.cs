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
    public class BasketPage : Page
    {
        const string removeButtonsLocator = "button[name=remove_cart_item]";
        const string tableWithProductsLocator = "#box-checkout-summary table";

        public BasketPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = removeButtonsLocator)]
        IList<IWebElement> removeButtons;

        [FindsBy(How = How.CssSelector, Using = tableWithProductsLocator)]
        IWebElement tableWithProducts;

        public bool ExistAnyProductsInBasket()
        {
            return removeButtons.FirstOrDefault() != null;
        }

        public void RemoveAllProducts()
        {
            var table = driver.FindElement(By.CssSelector(tableWithProductsLocator));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(removeButtonsLocator))).Click();
            wait.Until(ExpectedConditions.StalenessOf(table));
        }
    }
}
