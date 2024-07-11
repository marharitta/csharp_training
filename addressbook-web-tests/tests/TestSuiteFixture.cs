using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [SetUpFixture]   
    public class TestSuiteFixture
    {

        [OneTimeSetUp]
        public void InitApplicationManager() 
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
        }

    }
    
}
