
using System.Security.Cryptography;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "MyNewName";
            contact.MiddleName = null;
            contact.LastName = "MyNewLastName";
            contact.Email = null;
            contact.Telwork = null;

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(1, contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
 }
