﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MantisTest
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected LoginHelper loginHelper;

        public RegistrationHelper Registration { get; private set; }
        public ProjectHelper Project { get; private set; }
        public AdminHelper Admin { get; private set; }
        public APIHelper API { get; private set; }
        public FtpHelper Ftp { get; private set; }


        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() 
        {
            driver = new FirefoxDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost:8080/mantisbt";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            Project = new ProjectHelper(this);
            Admin = new AdminHelper(this,baseURL);
            API = new APIHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }

            return app.Value;
        }
       
        public IWebDriver Driver
        {
            get { return driver; }

        }
        public LoginHelper Auth
        {
            get
            { return loginHelper; }
        }
    }
}
