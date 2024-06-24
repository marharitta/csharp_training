
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : TestBase
    {

        [Test]
        public void DeleteGroupTestCaseTest()
        {
            navigator.OpenHomePage();
            loginHelper.LogIn(new AccountData("admin", "secret"));
            groupHelper.SelectGroupToDelete();
            groupHelper.SubmitDeleteGroup();
            loginHelper.Logoff();

        }

    }
}
