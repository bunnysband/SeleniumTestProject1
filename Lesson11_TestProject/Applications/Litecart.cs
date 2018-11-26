using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;
using Lesson11_TestProject.Pages;

namespace Lesson11_TestProject.Applications
{
    public class Litecart
    {
        public MainPage MainPage { get; private set; }
        public ProductPage ProductPage { get; private set; }
        public CartBlock CartBlock { get; private set; }
        public BasketPage BasketPage { get; private set; }

        public Litecart(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            MainPage = new MainPage(driver);
            ProductPage = new ProductPage(driver);
            CartBlock = new CartBlock(driver);
            BasketPage = new BasketPage(driver);
            MainPage.Initialize();
            ProductPage.Initialize();
            CartBlock.Initialize();
            BasketPage.Initialize();
        }

        public void LoadMainPage()
        {
            MainPage.Load();
        }

        public void AddProductsToCart(int numberOfProducts)
        {
            for (int i = 1; i <= numberOfProducts; i++)
            {
                LoadMainPage();
                MainPage.OpenFirstProduct();
                ProductPage.AddProductToCart();
                CartBlock.CheckProductCountInCart(i);
            }
        }
     
        public void OpenBasket()
        {
            CartBlock.Checkout();
        }

        public void RemoveAllProductsFromBasket()
        {
            while (BasketPage.ExistAnyProductsInBasket())
            {
                BasketPage.RemoveAllProducts();
            }
        }
    }
}
