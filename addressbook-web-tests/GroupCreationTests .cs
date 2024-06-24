
namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.LogIn(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "fff";
            group.Header = "ddd";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logoff();
        }
    }

}

