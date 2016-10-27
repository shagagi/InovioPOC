using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InovioPOC.Configuration
{
    public class Base
    {
        // Driver used in the entire solution

        public IWebDriver Driver { get; set; }
    }
}