using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }
        [OneTimeTearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
