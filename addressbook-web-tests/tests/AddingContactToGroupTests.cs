namespace Addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetOneByIndex(0);
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().First(x => !oldList.Any(y => y.Id == x.Id));

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
