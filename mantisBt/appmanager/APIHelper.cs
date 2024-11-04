using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis;

namespace MantisTest
{
    public  class APIHelper : HelperBase
    {
        private object baseUrl;

        public APIHelper(ApplicationManager manager): base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public async Task<string> CreateNewIssueAsync(AccountData account, ProjectModel project, DataIssue dataIssue)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = dataIssue.Summary; ;
            issue.description = dataIssue.Description;
            issue.category = dataIssue.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id; 
            return await client.mc_issue_addAsync(account.Name, account.Password, issue);
        }

        public async Task<List<ProjectModel>> GetProjectsListAsync(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            ProjectData[] projects = await client.mc_projects_get_user_accessibleAsync(account.Name, account.Password);
            return projects.Select(project => new ProjectModel(project)).ToList();
        }

        public async Task<string> CreateProjectAsync(AccountData account, ProjectModel project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = project.ProjectName;
            projectData.inherit_global = project.ProjectInheritGlobal;
            projectData.description = project.ProjectDescription;


            return await client.mc_project_addAsync(account.Name, account.Password, projectData);
            
        }
    }
}
