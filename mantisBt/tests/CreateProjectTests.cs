using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;


namespace MantisTest
{
    public class CreateProjectTests :TestBase
    {
        [Test]
        public async Task TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass",

            };

            app.Project.LogInMantis(account);


            ProjectModel project = new ProjectModel();
            project.GenerateRandom();

 //           List<ProjectModel> oldProjects = app.Project.GetProjList();
            List<ProjectModel> oldProjects = await app.API.GetProjectsListAsync(account);
            app.Project.Create(project);

//            List<ProjectModel> newProjects = app.Project.GetProjList();
            List<ProjectModel> newProjects = await app.API.GetProjectsListAsync(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
