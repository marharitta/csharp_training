
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : TestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.Remove(2); 
            app.Auth.Logoff();
        }

    }
}
