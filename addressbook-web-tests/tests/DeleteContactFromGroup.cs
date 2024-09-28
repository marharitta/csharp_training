namespace Addressbook_web_tests
{
    public class DeleteContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeleteContacFromGroup()
        {
            GroupData group = GroupData.GetOneWithContacts();
            if (group == null)
            {
                group = GroupData.GetOneByIndex(0);
                if (group == null)
                {
                    GroupData grouptoAdd = new GroupData(GenerateEngNumRandomString(10))
                    {
                        Footer = GenerateEngNumRandomString(10),
                        Header = GenerateEngNumRandomString(10)
                    };

                    app.Groups.Create(grouptoAdd);
                    group = GroupData.GetOneByIndex(0);
                }

                ContactData contactToAdd = ContactData.GetOneByIndex(0);
                if (contactToAdd == null)
                {
                    contactToAdd = new ContactData(GenerateEngNumRandomString(20), GenerateEngNumRandomString(20))
                    {
                        Nickname = GenerateEngNumRandomString(20),
                        Address = GenerateEngNumRandomString(20),
                        TelephoneHome = GenerateEngNumRandomString(20),
                    };
                    
                    app.Contacts.Create(contactToAdd);
                    contactToAdd = ContactData.GetOneByIndex(0);
                }

                app.Contacts.AddContactToGroup(contactToAdd, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contactToDelete = oldList.First();

            app.Contacts.DeleteContactFromGroup(contactToDelete, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToDelete);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
