namespace Addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetOneByIndex(0);
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

            List<ContactData> oldList = group.GetContacts();
            ContactData contactToAdd = null;
            if (oldList.Count > 0)
            {
                contactToAdd = ContactData.GetAll().FirstOrDefault(x => !oldList.Any(y => y.Id == x.Id));
            }

            if (contactToAdd == null)
            {
                contactToAdd = new ContactData(GenerateEngNumRandomString(20), GenerateEngNumRandomString(20))
                {
                    Nickname = GenerateEngNumRandomString(20),
                    Address = GenerateEngNumRandomString(20),
                    TelephoneHome = GenerateEngNumRandomString(20),
                };

                app.Contacts.Create(contactToAdd);
                contactToAdd = ContactData.GetAll().FirstOrDefault(x => !oldList.Any(y => y.Id == x.Id));
            }

            app.Contacts.AddContactToGroup(contactToAdd, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contactToAdd);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
