using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    [TestFixture]
    public class AddNewIssueTests: TestBase
    {
        [Test]
        public async Task AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass"
            };
            ProjectModel project = new ProjectModel()
            {
                Id = "4"
            };
            DataIssue issue = new DataIssue()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "test"
            };

            var output = await app.API.CreateNewIssueAsync(account,project, issue);
            Console.WriteLine(output);
        }
    }
}
