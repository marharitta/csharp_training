
namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            LogIn(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "fff";
            group.Header = "ddd";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logoff();
        }
    }

}

