using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addressbook_web_tests;

namespace Addressbook_web_tests
{
    public class GroupTestBase: AuthTestBase 
    {
        [TearDown]
        public void CompareGroupUI_DB()
        { 
            if(PERFORM_LONG_UI_CHECK)
            {
                List<GroupData> fromUi = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUi.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromUi, fromDB);
            }

        }
    }
}
