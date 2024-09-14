using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 2; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = GenerateRandomString(30),
                    LastName = GenerateRandomString(30),
                    MiddleName = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Mobile = GenerateRandomString(30),

                });
            }

            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));

        }
        

        [Test, TestCaseSource("ContactDataFromJsonFile")]//nameof(RandomContactDataProvider)
        public void TheContactCreationTestCaseTest(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContact.Count);

        }
    }
}



