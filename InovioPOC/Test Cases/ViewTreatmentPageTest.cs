using NUnit.Framework;
using InovioPOC.Configuration;
using InovioPOC.Utilities;
using System.Configuration;
using InovioPOC.Page_Objects;
using System.Threading;

namespace InovioPOC.Test_Cases
{
    // View Treatment Page Test Class inherits from Drivers Class
    class ViewTreatmentPageTest : Drivers
    {
        // Read the Excel path which contains the username and password from the configuration file
        public static string ExcelPath = ConfigurationManager.AppSettings["ExcelPath"];

        // According to the username and password a login should be executed
        // View button is clicked from the Home page
        // Search button is clicked from the View page
        [Test]
        public void ViewTreatmentPageTestMethod()
        {
            DataReader.PopulateInCollection(ExcelPath);
            LoginPage loginpage = new LoginPage(Driver);
            loginpage.LoginMethod(DataReader.ReadData(1, "Username"), DataReader.ReadData(1, "Password"));
            ViewTreatmentPage viewtreatmentpage = new ViewTreatmentPage(Driver);
            viewtreatmentpage.ClickView();
            viewtreatmentpage.ClickSearch();
        }
    }
}
