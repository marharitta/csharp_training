using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void TheGroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Footer = null;
            newData.Header = null;
            int modifyIndex = 0;

            app.Navigator.GoToGroupsPage();
            if (app.Groups.IsElementPresent(By.XPath($"//input[@name='selected[]']")) == false)
            {
                GroupData group = new GroupData("aaa");
                group.Footer = "fff";
                group.Header = "ddd";

                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count , app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[modifyIndex].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
                
            }

        }
    }
}
