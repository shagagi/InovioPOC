using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace InovioPOC.Configuration
{
    [TestFixture]
    public class Drivers : Base
    {
        // Read the Application URL from the configuration file
        string _applicationurl = ConfigurationManager.AppSettings["URL"];
        
        // Read the Browser from the configuration file
        string _browserType = ConfigurationManager.AppSettings["Browser"];

        public Drivers()
        {
           
        }

        [SetUp]
        public void InitializeTest()
        {
            // For each test case the following steps are executed before running the test case
            // Initialize the Driver as per the Browser type selected from the configuration file
            SelectDriverInstance(_browserType);
            // Open the URL of the application
            Driver.Navigate().GoToUrl(_applicationurl);
            // Maximize the browser page
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseTest()
        {
            //For each test case the following steps are executed after running the test case
            // Close the browser page
            Driver.Quit();
        }
        public void SelectDriverInstance(string browserType)
        {
            // In case the browser is firefox initialize the Firefox driver
            if (browserType == "Firefox")
                Driver = new FirefoxDriver();
            // In case the browser is Chrome initialize the Chrome driver
            else if (browserType == "Chrome")
                Driver = new ChromeDriver("C:\\Users\\Syoussef\\Documents\\Visual Studio 2015\\Projects\\InovioPOC\\packages\\Selenium.WebDriver.ChromeDriver.2.24.0.0\\driver");
            // In case the browser is IE initialize the IE driver
            else if (browserType == "IE")
                Driver = new InternetExplorerDriver("C:\\Users\\Syoussef\\Documents\\Visual Studio 2015\\Projects\\InovioPOC\\packages\\Selenium.WebDriver.IEDriver.3.0.0.0\\driver");
            // In case the browser is Opera initialize the Opera driver
            else if (browserType == "Opera")
                Driver = new OperaDriver("C:\\Users\\Syoussef\\Documents\\Visual Studio 2015\\Projects\\InovioPOC\\packages\\Opera");
        }   
    }
    // Add Extension to the driver used in the entire solution
    public static class driverExtentions
    {
        // Explicit Wait for existence of an elements depending on time and method
        public static void ExplicitWait(this IWebDriver driver, int time, string method, string locator)
        {
            if (method == "Id")
            {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementExists((By.Id(locator))));
            }
            else if (method == "ClassName")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementExists((By.ClassName(locator))));
            }
            else if (method == "XPath")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementExists((By.XPath(locator))));
            }
            else if (method == "Name")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementExists((By.Name(locator))));
            }
            else if (method == "CssSelector")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementExists((By.CssSelector(locator))));
            }
        }
        // Explicit Wait for invisibility of an elements depending on time and method
        public static void ExplicitWaitInvisible(this IWebDriver driver, int time, string method, string locator)
        {
            if (method == "Id")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.Id(locator))));
            }
            else if (method == "ClassName")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.ClassName(locator))));
            }
            else if (method == "XPath")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath(locator))));
            }
            else if (method == "Name")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.Name(locator))));
            }
            else if (method == "CssSelector")
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.CssSelector(locator))));
            }
        }
    }
}