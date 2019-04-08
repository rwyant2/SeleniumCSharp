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
    class TextFieldTests
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
        public void TextFieldTest()
        {
            driver.FindElementById("textField").SendKeys("Please hire me. I need money for retirement. :-O");
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("textResult").Text;
            Assert.True(actualText.Contains("Please hire me. I need money for retirement. :-O"));
        }

        [Test]
        public void IntentionalFailTextField()
        {
            driver.FindElementById("textField").SendKeys("Please hire me. I need money for retirement. :-O");
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("textResult").Text;
            Assert.True(actualText.Contains("Subscribe To PewDiePie"), "Oh noes! TextField has incorrect value.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}