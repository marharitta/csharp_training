
namespace Addressbook_web_tests
{
    public  class TestBase
    {

        protected ApplicationManager app;

         [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();

        }        
    }
}
