
namespace Addressbook_web_tests
{
    public  class TestBase
    {

        protected ApplicationManager app;

         [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
           app.Stop();
        }
        
    }
}
