using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantisTest
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base (manager) { }

        public void LogInMantis(AccountData account)
        {
            manager.Registration.OpenMainPage();
            manager.Auth.LogIn(account);
        }

        public void Create(ProjectModel project)
        {
            GoToProjectsPage();
            CreateProjectPage();
            FillCreationForm(project);
            SubmitAddProject();
        }

        public void CreateProjectPage()
        {
            driver.FindElement(By.XPath("//input[@value=\"Create New Project\"]")).Click();
        }

        public void GoToProjectsPage()
        {
            driver.Url = "http://localhost:8080/mantisbt/manage_proj_page.php";
        }

        public void FillCreationForm(ProjectModel project)
        {
            Type(By.Id("project-name"), project.ProjectName);
            Select(By.Id("project-status"), ((int)project.ProjectStatus).ToString());
            SetCheckbox(By.Id("project-inherit-global"), project.ProjectInheritGlobal);
            Select(By.Id("project-view-state"), ((int)project.ProjectViewState).ToString());
            Type(By.Id("project-description"), project.ProjectDescription);
        }

        public void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//input[@value=\"Add Project\"]")).Click();  
        }

        public void DeleteProject(int index)
        {
            GoToProjectsPage();
            SelectProject(index);
            DeleteButtonClick();
        }

        public void DeleteButtonClick()
        {
            driver.FindElement(By.XPath("//input[@value=\"Delete Project\"]")).Click();
            driver.FindElement(By.XPath("//input[@value=\"Delete Project\"]")).Click();
        }

        public void SelectProject(int index)
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/table/tbody/tr[" + index + "]/td/a")).Click();
        }

        public List<ProjectModel> GetProjList()
        {
            List<ProjectModel> projectList = new List<ProjectModel>();
            GoToProjectsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"content\"]/div[2]/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectModel() {
                    ProjectName = element.FindElement(By.XPath("td[1]/a")).Text,
                    ProjectStatus = (Status)Enum.Parse(typeof(Status), element.FindElement(By.XPath("td[2]")).Text, true),
                    // ENABLED missed
                    ProjectViewState = (ViewState)Enum.Parse(typeof(ViewState), element.FindElement(By.XPath("td[4]")).Text, true),
                    ProjectDescription = element.FindElement(By.XPath("td[5]")).Text,
                });
            }

            return projectList;
        }


    }
}
