using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lesson11_TestProject.Tests
{
    [TestFixture]
    public class Lesson11_Test1 : TestBase
    {
        [Test]
        public void Test()
        {
            litecart.LoadMainPage();
            litecart.AddProductsToCart(3);
            litecart.OpenBasket();
            litecart.RemoveAllProductsFromBasket();
        }
    }
}
