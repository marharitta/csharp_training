
namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "Ivan";
            contact.LastName = "Ivanov";

            app.Contact.Modified(1, contact);

            app.Auth.Logoff();
        }
    }
 }
