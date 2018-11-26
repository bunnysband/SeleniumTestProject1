using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lesson11_TestProject.Pages
{
    public class MainPage: Page
    {
        const string url = "http://localhost/litecart";
        const string productsLocator = "#main ul.products .product";
        public MainPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = productsLocator)]
        IList<IWebElement> products;

        public void OpenFirstProduct()
        {
            products.First().Click();
        }

        public void Load()
        {
            driver.Url = url;
        }
    }
}
