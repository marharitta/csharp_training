namespace Addressbook_web_tests
{
        [TestFixture]
        public class ContactCreationTests : TestBase
        {
           
            [Test]
            public void TheContactCreationTestCaseTest()
            {
                app.Navigator.OpenHomePage();
                app.Auth.LogIn(new AccountData("admin", "secret"));
                app.Contact.AddNewContact();
                ContactData contact = new ContactData();
                contact.FirstName = "Petr"; 
                contact.LastName = "Petrov";
                app.Contact.FillContactForm(contact);
                app.Contact.SubmiteContactCreation();
                app.Auth.Logoff();
           }
        }
    }



