
namespace Addressbook_web_tests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            System.Console.Out.WriteLine(app.Contacts.GetNumberOfSearchResults());
        }

    }
}
