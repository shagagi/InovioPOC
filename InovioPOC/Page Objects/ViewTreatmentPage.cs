using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using InovioPOC.Configuration;

namespace InovioPOC.Page_Objects
{
    public class ViewTreatmentPage 
    {
        // Define a Driver
        IWebDriver _driver;

        // Elements of the Login Page
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/h4")]
        private IWebElement Overlay { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'viewer')]")]
        private IWebElement Viewbtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnReviewerSearch")]
        private IWebElement Searchbtn { get; set; }

        // Initialization for the driver
        public ViewTreatmentPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }
        // Click on View button from Home page
        public void ClickView()
        {
            Viewbtn.Click();
        }
        // Click on Search button from View page
        // Wait for the overlay to disappear
        public void ClickSearch()
        {
            _driver.ExplicitWait(10, "XPath", "/html/body/div[4]/h4");
            _driver.ExplicitWaitInvisible(10, "XPath", "/html/body/div[4]/h4");
            Searchbtn.Click();
        }
    }
}