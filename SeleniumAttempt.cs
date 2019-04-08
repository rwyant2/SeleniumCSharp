using System;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

// Ideally, I'd be using NUnit to run these. My evnironment is having issues
// running NUnit test from Visual Studio Code for Ubuntu. Since this is a demo
// for a job interview, I'm putting that on the back burner.

// For now, the goal is to test my SpringBootProject website a'la the
// SeleniumJavaGradle project and to demonstrate I can learn enough C#
// In a weekend to write tests. In reality, I can always figure out the 
// testing infrastructure later.

namespace SeleniumCSharp
{
    
    class SeleniumAttempt
    {
        // private static FirefoxDriver driver;

        static void other(string[] args)
        {
            // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"/home/richard-u18/git/SeleniumCSharp/webdrivers", "geckodriver");
            // service.Port = 64444;
            // driver = new FirefoxDriver(service);

            CheckBoxTests cbt = new CheckBoxTests();
            cbt.SetUp(); cbt.OneTwo(); cbt.TearDown();
            cbt.SetUp(); cbt.IntentionalFail(); cbt.TearDown();
            cbt.SetUp(); cbt.TwoThree(); cbt.TearDown();
            
        }
    }
}        