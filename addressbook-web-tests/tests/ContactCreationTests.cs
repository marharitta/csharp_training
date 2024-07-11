namespace Addressbook_web_tests
{
        [TestFixture]
        public class ContactCreationTests : TestBase
        {
           
            [Test]
            public void TheContactCreationTestCaseTest()
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr"; 
                contact.LastName = "Petrov";
                app.Contact.Create(contact);

           }
        }
    }



