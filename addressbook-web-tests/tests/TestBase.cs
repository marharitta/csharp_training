﻿
namespace Addressbook_web_tests
{
    public  class TestBase
    {

        protected ApplicationManager app;

         [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
           app.Stop();
        }
        
    }
}
