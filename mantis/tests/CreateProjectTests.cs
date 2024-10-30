using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;


namespace mantis
{
    public class CreateProjectTests :TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass",

            };

            app.Project.LogInMantis(account);


            ProjectData project = new ProjectData();
            project.GenerateRandom();

            List<ProjectData> oldProjects = app.Project.GetProjList();
            app.Project.Create(project);

            List<ProjectData> newProjects = app.Project.GetProjList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
