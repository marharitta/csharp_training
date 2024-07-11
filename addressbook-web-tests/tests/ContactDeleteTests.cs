using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactDeleteTests: TestBase
    {
        [Test]
        public void DeleteContactTest()
        {

            app.Contact.Remove("1");

            app.Auth.Logoff();
        }
    }
}
