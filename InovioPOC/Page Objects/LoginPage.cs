using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using InovioPOC.Configuration;

namespace InovioPOC.Page_Objects
{
    public class LoginPage
    {
        // Define a Driver
        IWebDriver _driver;

        // Elements of the Login Page
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/h4")]
        private IWebElement Overlay { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement UsernameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-success")]
        private IWebElement Loginbtn { get; set; }

        // Initialization for the driver
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        // Login Method takes username and password and click on Login button
        // Waiting for the overlay to disappear
        public void LoginMethod(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            Loginbtn.Click();
            _driver.ExplicitWait(10, "XPath", "/html/body/div[4]/h4");
            _driver.ExplicitWaitInvisible(10, "XPath", "/html/body/div[4]/h4");
        }
    }
}