using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactDeleteTests: AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            if (app.Groups.IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == false)
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);
            
            Assert.AreEqual(oldContacts.Count -1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData  toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}
