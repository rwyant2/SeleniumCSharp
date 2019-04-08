using System;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharp
{
    [TestFixture]
    class DropDownTests
    {
        private ChromeDriver driver;
        private ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"/home/richard-u18/git/SeleniumCSharp/webdrivers", "chromedriver");

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "localhost:8080";
            driver.FindElementByLinkText("here").Click();
        }    

        [Test]
        public void DropDownTomato()
        {
            //SelectElement dropDown = new SelectElement(driver.FindElementById("dropDownSelection")); // if I want a persistent reference
            (new SelectElement(driver.FindElementById("dropDownSelection"))).SelectByText("tomato");
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("dropDownResult").Text;
            Assert.AreEqual(actualText,"red");
        }

        [Test]
        public void DropDownMustard()
        {
            (new SelectElement(driver.FindElementById("dropDownSelection"))).SelectByText("mustard");
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("dropDownResult").Text;
            Assert.AreEqual(actualText,"yellow");
        }

        [Test]
        public void DropDownOnion()
        {
            (new SelectElement(driver.FindElementById("dropDownSelection"))).SelectByText("onions");
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("dropDownResult").Text;
            Assert.AreEqual(actualText,"white");
        }

        [Test]
        public void DropDownDefault()
        {
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("dropDownResult").Text;
            Assert.AreEqual(actualText,"yellow");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}