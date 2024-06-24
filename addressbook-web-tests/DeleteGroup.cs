
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : TestBase
    {

        [Test]
        public void DeleteGroupTestCaseTest()
        {
            OpenHomePage();
            LogIn(new AccountData("admin", "secret"));
            SelectGroupToDelete();
            SubmitDeleteGroup();
            Logoff();

        }

    }
}
