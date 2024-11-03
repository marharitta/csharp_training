using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis
{
    public class DeleteProjectTests : TestBase
    {
        [Test]
        public void TestProjectDelete()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass",

            };

            app.Project.LogInMantis(account);

            List<ProjectData> oldProjects = app.Project.GetProjList();
            if(oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData();
                project.GenerateRandom();

                app.Project.Create(project);
                oldProjects = app.Project.GetProjList();
            }

            int deleteProjectIndex = 1;
            app.Project.DeleteProject(deleteProjectIndex);

            List<ProjectData> newProjects = app.Project.GetProjList();
            oldProjects.RemoveAt(deleteProjectIndex -1 );
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
