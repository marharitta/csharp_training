using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTest
{
    public class DeleteProjectTests : TestBase
    {
        [Test]
        public async Task TestProjectDelete()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass",

            };

            app.Project.LogInMantis(account);

            List<ProjectModel> oldProjects = app.Project.GetProjList();
            if(oldProjects.Count == 0)
            {
                ProjectModel project = new ProjectModel();
                project.GenerateRandom();

//                app.Project.Create(project);
                await app.API.CreateProjectAsync(account, project);
                oldProjects = await app.API.GetProjectsListAsync(account);
            }

            int deleteProjectIndex = 1;
            app.Project.DeleteProject(deleteProjectIndex);

            List<ProjectModel> newProjects = await app.API.GetProjectsListAsync(account);
            oldProjects.RemoveAt(deleteProjectIndex -1 );
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
