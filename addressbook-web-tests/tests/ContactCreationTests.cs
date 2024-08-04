using System.Security.Cryptography;

namespace Addressbook_web_tests
{
        [TestFixture]
        public class ContactCreationTests : AuthTestBase
    {
           
            [Test]
            public void TheContactCreationTestCaseTest()
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr"; 
                contact.LastName = "Petrov";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContact.Count);


        }
    }
    }



