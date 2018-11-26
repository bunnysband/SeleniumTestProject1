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
    public class Page
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait wait;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void Initialize()
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
