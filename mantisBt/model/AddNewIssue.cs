using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis;

namespace mantis
{
    [TestFixture]
    public class AddNewIssueTests: TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass"
            };
            ProjectData project = new ProjectData()
            {
                Id = "4"
            };
            DataIssue issue = new DataIssue()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "test"
            };

            var output = app.API.CreateNewIssueAsync(account,project, issue);
            Console.WriteLine(output);
        }
    }
}
