using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void LogIn(AccountData account)
        {
            if (IsLoggedIn())
            {

                if (IsLoggedIn(account))
                {
                    return;
                }
                Logoff();
            }

            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logoff()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Id("logout-link")).Click();
                driver.FindElement(By.Name("username"));
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("logout-link"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
               
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Id("logout-link")).FindElement(By.TagName("b")).Text;                       
            return text.Substring(1, text.Length - 2);
        }
    }
}
