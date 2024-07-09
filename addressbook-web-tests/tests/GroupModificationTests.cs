using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Footer = null;
            newData.Header = null;

            app.Groups.Modify(1, newData); 
        }
    }
}
