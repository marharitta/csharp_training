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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContact.Count);


        }
    }
    }



