using System;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

// Initially I was having issues running from Visual Studio Code.
// I have this fixed, but I want to keep this class handy around.
// A goal I have for the portfolio is to have a C# example a'la SeleniumJavaGradle.
// For that, I'll need to be able to run tests programatically, which is what this does.

namespace SeleniumCSharp
{
    
    class SeleniumAttempt
    {
        // private static FirefoxDriver driver;

        static void other(string[] args) // Renaming from Main so I don't get duplicate entry point error
        {
            // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"/home/richard-u18/git/SeleniumCSharp/webdrivers", "geckodriver");
            // service.Port = 64444;
            // driver = new FirefoxDriver(service);

            CheckBoxTests cbt = new CheckBoxTests();
            cbt.SetUp(); cbt.OneTwo(); cbt.TearDown();
            cbt.SetUp(); cbt.IntentionalFailCheckBox(); cbt.TearDown();
            cbt.SetUp(); cbt.TwoThree(); cbt.TearDown();
            
        }
    }
}        