using System;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace SeleniumCSharp
{
    [TestFixture]
    class RadioButtonTests
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
        public void RadioChoiceA()
        {
            driver.FindElementById("radioButtonSelection1").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("radioResult").Text;
            Assert.AreEqual(actualText,"apple");
        }

        [Test]
        public void RadioChoiceB()
        {
            driver.FindElementById("radioButtonSelection2").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("radioResult").Text;
            Assert.AreEqual(actualText,"banana");
        }

        [Test]
        public void RadioChoiceC()
        {
            driver.FindElementById("radioButtonSelection3").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("radioResult").Text;
            Assert.AreEqual(actualText,"cherry");
        }

        [Test]
        public void RadioChoiceDefault()
        {
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("radioResult").Text;
            Assert.AreEqual(actualText,"");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}