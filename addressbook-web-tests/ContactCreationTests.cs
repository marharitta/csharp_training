namespace Addressbook_web_tests
{
        [TestFixture]
        public class ContactCreationTests : TestBase
        {
           
            [Test]
            public void TheContactCreationTestCaseTest()
            {
                navigator.OpenHomePage();
                loginHelper.LogIn(new AccountData("admin", "secret"));
                AddNewContact();
                ContactData contact = new ContactData();
                contact.FirstName = "Petr"; 
                contact.LastName = "Petrov";
                FillContactForm(contact);
                SubmiteContactCreation();
                loginHelper.Logoff();
           }
        }
    }



