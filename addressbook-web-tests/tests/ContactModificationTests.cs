
using System.Security.Cryptography;
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData newContact = new ContactData();
            newContact.FirstName = "MyNewName";
            newContact.MiddleName = null;
            newContact.LastName = "MyNewLastName";
            newContact.Email = null;
            newContact.Telwork = null;

            if (app.Groups.IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == false)
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            int modifyIndex = new Random().Next(oldContacts.Count);
            ContactData oldData = oldContacts[modifyIndex];

            app.Contacts.Modify(oldData.Id, newContact);

            List<ContactData> newContacts = ContactData.GetAll();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);

            oldContacts[modifyIndex].FirstName = newContact.FirstName;
            oldContacts[modifyIndex].LastName = newContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContact.FirstName, contact.FirstName);
                    Assert.AreEqual(newContact.LastName, contact.LastName);
                }

            }
        }
    }
 }
