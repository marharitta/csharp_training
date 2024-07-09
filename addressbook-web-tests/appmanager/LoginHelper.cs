﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)      
        { 
        }
        public void LogIn(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logoff()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }

}
