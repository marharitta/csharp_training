﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
            
    }
}
