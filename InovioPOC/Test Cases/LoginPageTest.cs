using NUnit.Framework;
using InovioPOC.Configuration;
using InovioPOC.Utilities;
using System.Configuration;
using InovioPOC.Page_Objects;

namespace InovioPOC.Test_Cases
{
    // Login Page Test Class inherits from Drivers Class
    class LoginPageTest: Drivers
    {
        // Read the Excel path which contains the username and password from the configuration file
        public static string ExcelPath = ConfigurationManager.AppSettings["ExcelPath"];

        // According to the username and password a login should be executed
        [Test]
        public void LoginPageTestMethod()
        {
            DataReader.PopulateInCollection(ExcelPath);
            LoginPage loginpage = new LoginPage(Driver);
            loginpage.LoginMethod(DataReader.ReadData(1, "Username"), DataReader.ReadData(1, "Password"));
        }
    }
}