
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : AuthTestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            app.Navigator.GoToGroupsPage();

            if (app.Groups.IsElementPresent(By.XPath($"//input[@name='selected[]']")) == false)
            {
                GroupData group = new GroupData("aaa");
                group.Footer = "fff";
                group.Header = "ddd";

                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }

    }
}
