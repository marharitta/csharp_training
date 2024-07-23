using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(1, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
