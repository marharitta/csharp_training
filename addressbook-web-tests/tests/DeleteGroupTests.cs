
namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : AuthTestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);
        }

    }
}
