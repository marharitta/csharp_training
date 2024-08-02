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

                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(0);
            
            Assert.AreEqual(oldContacts.Count -1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContact);

        }
    }
}
