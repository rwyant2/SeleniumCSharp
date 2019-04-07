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
    class CheckBoxTests
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

        public CheckBoxTests()
        {}

        [Test]
        public void OneTwo()
        {
            driver.FindElementById("checkBoxSelection1").Click();
            driver.FindElementById("checkBoxSelection2").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("checkBoxResult").Text;
            Assert.True(actualText.Contains("one"));
            Assert.True(actualText.Contains("two"));
            Assert.False(actualText.Contains("three"));
            Console.WriteLine("******************* Yay OneTwo passed!");
        }

        [Test]
        public void IntentionalFail()
        {
            driver.FindElementById("checkBoxSelection1").Click();
            driver.FindElementById("checkBoxSelection2").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("checkBoxResult").Text;
            Assert.True(actualText.Contains("Subscribe To PewDiePie"), "**********************************Oh noes! Checkboxes not giving correct value");
            Console.WriteLine("******************* Yay it passed!"); //This should not appear
        }

        [Test]
        public void TwoThree()
        {
            driver.FindElementById("checkBoxSelection2").Click();
            driver.FindElementById("checkBoxSelection3").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("checkBoxResult").Text;
            Assert.False(actualText.Contains("one"));
            Assert.True(actualText.Contains("two"));
            Assert.True(actualText.Contains("three"));
            Console.WriteLine("******************* Yay TwoThree passed!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}