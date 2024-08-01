
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : AuthTestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (app.Groups.IsElementPresent(By.XPath($"//input[@name='selected[]']")) == true)
            {
                app.Groups.Remove(0);
            }
            else
            {
                GroupData group = new GroupData("aaa");
                group.Footer = "fff";
                group.Header = "ddd";

                app.Groups.Create(group);

                app.Groups.Remove(0);
            }

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
