using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class LoginTests: TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logoff();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.LogIn(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.Logoff();

            AccountData account = new AccountData("admin", "567345");
            app.Auth.LogIn(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
