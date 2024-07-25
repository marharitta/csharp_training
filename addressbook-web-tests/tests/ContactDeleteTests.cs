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
            List<ContactData> oldContact = app.Contact.GetContactList();

            if (app.Groups.IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == true)
            {
                app.Contact.Remove(0);
            }
            else
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";

                app.Contact.Create(contact);

                app.Contact.Remove(0);
            }

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
