
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : TestBase
    {

        [Test]
        public void DeleteGroupTestCaseTest()
        {
            app.Groups.Remove(1);
            app.Auth.Logoff();
        }

    }
}
