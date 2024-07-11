
namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = null;
            contact.MiddleName = null;
            contact.LastName = null;
            contact.Email = null;
            contact.Telwork = "6543219";

            app.Contact.Modify(1, contact);
        }
    }
 }
