using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis;
using Mantis;

namespace mantis
{
    public  class APIHelper : HelperBase
    {
        private object baseUrl;

        public APIHelper(ApplicationManager manager): base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public string CreateNewIssueAsync(AccountData account, ProjectData project, DataIssue dataIssue)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = dataIssue.Summary; ;
            issue.description = dataIssue.Description;
            issue.category = dataIssue.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id; 
            var output = Task.Run(() => client.mc_issue_addAsync(account.Name, account.Password, issue)).Result;

            return output;
        }
    }
}
