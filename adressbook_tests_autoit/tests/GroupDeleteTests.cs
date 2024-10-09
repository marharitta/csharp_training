using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace adressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeleteTests: TestBase
    {
        [Test]
        public void TestGroupDelete()
        {
            app.Groups.Add(new GroupData()
            {
                Name = "Group to delete"
            });

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            int groupIndexToDelete = 0;
            app.Groups.DeletGroup(groupIndexToDelete);
            oldGroups.RemoveAt(groupIndexToDelete);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups.Count, newGroups.Count);
        }

    }
}
