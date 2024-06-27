
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : TestBase
    {

        [Test]
        public void DeleteGroupTestCaseTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
            app.Groups.SelectGroupToDelete();
            app.Groups.SubmitDeleteGroup();
            app.Auth.Logoff();

        }

    }
}
