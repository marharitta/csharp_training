
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : AuthTestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.Remove(2); 
        }

    }
}
