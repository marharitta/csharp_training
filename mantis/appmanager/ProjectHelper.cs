using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base (manager) { }

        public void LogInMantis(AccountData account)
        {
            manager.Registration.OpenMainPage();
            manager.Auth.LogIn(account);
        }

        public void Create(ProjectData project)
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
            driver.FindElement(By.LinkText("Manage")).Click();
            driver.FindElement(By.LinkText("Manage Projects")).Click();

        }

        public void FillCreationForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.ProjectName);
            Select(By.Id("project-status"), ((int)project.ProjectStatus).ToString());
            SetCheckbox(By.Id("project-inherit-global"), project.ProjectInheritGlobal);
            Select(By.Id("project-view-state"), ((int)project.ProjectViewState).ToString());
            Type(By.Id("project-description"), project.ProjectDescription);
        }

        public void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//input[@value=\"Add Project\"]")).Click();  ///html/body/div/div[4]/div[3]/form/fieldset/span/input
        }

        public void DeleteProject(int v)
        {
            GoToProjectsPage();
            SelectProject(v);
            DelProject();
        }

        public void DelProject()
        {
            driver.FindElement(By.XPath("//input[@value=\"Delete Project\"]")).Click();
            driver.FindElement(By.XPath("//input[@value=\"Delete Project\"]")).Click();
        }

        public void SelectProject(int id)
        {
            driver.Url = "http://localhost:8080/mantisbt/manage_proj_edit_page.php?project_id=" + id;
        }
    }
}
