using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantisTest
{
    public class RegistrationHelper :HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.LinkText("Signup for a new account")).Click();
        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        public void FillRegistrationForm(AccountData account)  
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
    
            if (driver.FindElements(By.Id("logout-link")).Count > 0)
            {
                driver.FindElement(By.Id("logout-link")).Click();
            }
            else
            {
                manager.Driver.Url = "http://localhost:8080/mantisbt/login_page.php";
            }

            
        }

    }
}
