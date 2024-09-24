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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToRemove = oldContacts[0];
            app.Contacts.Remove(contactToRemove.Id);
            List<ContactData> newContacts = ContactData.GetAll();

            Assert.AreEqual(oldContacts.Count -1, newContacts.Count);


            oldContacts.Remove(contactToRemove);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}
