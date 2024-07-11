
namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Footer = "fff";
            group.Header = "ddd";
            app.Groups.Create(group);

        }
        [Test]
        public void EmptyGroupCreationTest()
        {       
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";
            app.Groups.Create(group);

        }
    }

}

