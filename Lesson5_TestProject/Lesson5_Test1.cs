using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumTestBase;
using System.Linq;
using System.Collections.Generic;

namespace Lesson5_TestProject
{
    [TestFixture]
    public class Lesson5_Test1 : TestBase
    {
        List<IWebElement> GetCountries()
        {
            return driver.FindElements(By.CssSelector("form[name=countries_form] .row")).ToList();
        }

        List<IWebElement> GetZonesFromCountry()
        {
            return driver.FindElements(By.CssSelector("#table-zones tr")).Skip(1).ToList();
        }

        List<IWebElement> GetZones()
        {
            return driver.FindElements(By.CssSelector("form[name=geo_zones_form] .row")).ToList();
        }

        List<IWebElement> GetCountriesFromZone()
        {
            return driver.FindElements(By.CssSelector("#table-zones select[name*=zone_code]")).ToList();
        }

        [Test]
        public void Test1()
        {
            List<string> countryNames = new List<string>();
            List<string> countryWithZonesUrls = new List<string>();
            driver.Url = countriesUrl;
            AdminLogin();
            for (int i = 0; i < GetCountries().Count; i++)
            {
                string countyName = GetCountries()[i].FindElements(By.TagName("td"))[4].FindElement(By.TagName("a")).Text;
                int zonesCount = Int32.Parse(GetCountries()[i].FindElements(By.TagName("td"))[5].Text);
                countryNames.Add(countyName);
                if (zonesCount > 0)
                {
                    string countryUrl = GetCountries()[i].FindElements(By.TagName("td"))[4].FindElement(By.TagName("a")).GetAttribute("href");
                    countryWithZonesUrls.Add(countryUrl);
                }
            }
            Assert.That(countryNames, Is.Ordered);
            foreach (var url in countryWithZonesUrls)
            {
                List<string> zoneNames = new List<string>();
                driver.Url = url;
                for (int i = 0; i < GetZonesFromCountry().Count; i++)
                {
                    string zoneName = GetZonesFromCountry()[i].FindElements(By.TagName("td"))[2].Text;
                    if (!string.IsNullOrEmpty(zoneName))
                        zoneNames.Add(zoneName);
                }
                Assert.That(zoneNames, Is.Ordered);
            }
        }

        [Test]
        public void Test2()
        {
            driver.Url = geoZonezUrl;
            AdminLogin();
            for (int i = 0; i < GetZones().Count; i++)
            {
                List<string> countryNames = new List<string>();
                GetZones()[i].FindElement(By.TagName("a")).Click();
                for (int j = 0; j < GetCountriesFromZone().Count; j++)
                {
                    var countryName = GetCountriesFromZone()[j].FindElement(By.CssSelector("option[selected]")).Text;
                    countryNames.Add(countryName);
                }
                Assert.That(countryNames, Is.Ordered);
                driver.Navigate().Back();
            }
        }
    }
}
