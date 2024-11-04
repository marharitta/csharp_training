using NUnit.Framework;
//using System.Text;

namespace MantisTest
{
    public  class TestBase
    {
 //       public static bool PERFORM_LONG_UI_CHECK = true;

        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();

        }

    }
}
