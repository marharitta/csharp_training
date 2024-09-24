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
    public class GroupModificationTests: GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll(); 
            GroupData oldData = oldGroups[modifyIndex];

            app.Groups.Modify(oldData.Id, newData);
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count , newGroups.Count);

            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                    break;
                }
                
            }

        }
    }
}
