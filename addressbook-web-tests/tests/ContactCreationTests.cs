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

            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContact = app.Contact.GetContactList();
            Assert.AreEqual(oldContact.Count + 1, newContact.Count);


        }
    }
    }



