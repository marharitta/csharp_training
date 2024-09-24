 
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTestCase : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count - 1));
            
            oldGroups.RemoveAt(0);
            Assert.That(newGroups, Is.EqualTo(oldGroups));

            foreach (GroupData group in newGroups)
            {
                Assert.That(toBeRemoved.Id, Is.Not.EqualTo(group.Id));
            }


        }

    }
}
