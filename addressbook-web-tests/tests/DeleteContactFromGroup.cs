namespace Addressbook_web_tests
{
    public class DeleteContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeleteContacFromGroup()
        {
            GroupData group = GroupData.GetOneWithContacts();
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = group.GetContacts().First();

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
