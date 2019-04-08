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
    class TextAreaTests
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
        public void TextAreaLongValue()
        {
            string inputText = "I can't really think of anything to put here" + 
                " so I'm going to ramble a bit. The whole point is to see what" +
                " happens with a text area that enforces its own word wrap";
            driver.FindElementById("textArea").SendKeys(inputText);
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("textAreaResult").Text;
            Assert.AreEqual(actualText,inputText);
        }

        [Test]
        public void TextAreaWithEnter()
        {
            string[] inputTextWithEnter = new string[3];
            inputTextWithEnter[0] = "This is to see what happens when a user";
            inputTextWithEnter[1] = "physically hits Enter between each line";
            inputTextWithEnter[2] = "It should just render as a space.";
            driver.FindElementById("textArea").SendKeys(inputTextWithEnter[0]);
            driver.FindElementById("textArea").SendKeys(Keys.Enter);
            driver.FindElementById("textArea").SendKeys(inputTextWithEnter[1]);
            driver.FindElementById("textArea").SendKeys(Keys.Enter);
            driver.FindElementById("textArea").SendKeys(inputTextWithEnter[2]);
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("textAreaResult").Text;
            Assert.AreEqual(actualText,inputTextWithEnter[0] + " " +
                inputTextWithEnter[1] + " " +
                inputTextWithEnter[2]
            );
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}