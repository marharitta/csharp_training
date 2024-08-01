﻿
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

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];

            if (app.Groups.IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == true)
            {
                app.Contact.Modify(0, newContact);
            }
            else
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";

                app.Contact.Create(contact);

                app.Contact.Modify(0, newContact);
            }

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newContact.FirstName;
            oldContacts[0].LastName = newContact.LastName;
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
