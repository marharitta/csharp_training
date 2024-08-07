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

            if (app.Groups.IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == false)
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";

                app.Contacts.Create(contact);
            }
                app.Contacts.Modify(0, newContact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
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
