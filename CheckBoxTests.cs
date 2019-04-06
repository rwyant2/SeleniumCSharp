using System;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace SeleniumCSharp
{
    class CheckBoxTests
    {
        private ChromeDriver driver;
        public CheckBoxTests(ChromeDriver driver)
        {
            this.driver = driver;
        }

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
        }

        [Test]
        public void IntentionalFail()
        {
            driver.FindElementById("checkBoxSelection1").Click();
            driver.FindElementById("checkBoxSelection2").Click();
            driver.FindElementByXPath("//input[@type='submit']").Click();
            string actualText = driver.FindElementById("checkBoxResult").Text;
            Assert.True(actualText.Contains("Subscribe To PewDiePie"), "**********************************Oh noes! Checkboxes not giving correct value");
            Console.WriteLine("******************* Yay it passed!");
        }

    }
}