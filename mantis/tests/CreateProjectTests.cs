using System;
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
            ProjectData project = new ProjectData()
            {
                ProjectName = StringHelper.GenerateEngNumRandomString(15),
                ProjectInheritGlobal = new Random(1).Next() == 1,
                ProjectDescription = StringHelper.GenerateRandomString(100),
                ProjectStatus = Status.release,
                ProjectViewState = ViewState.Private
            };

            app.Project.LogInMantis(account);
            app.Project.Create(project);


     //           Assert.AreEqual();

        }
    }
}
