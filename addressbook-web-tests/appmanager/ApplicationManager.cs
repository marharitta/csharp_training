using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Addressbook_web_tests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
        protected StringBuilder verificationErrors;

        protected string baseURL;

        public ApplicationManager() 
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/";
            verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
       
        public IWebDriver? Driver
        {
            get { return driver; }

        }

        public void Stop()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        { 
            get
                { return loginHelper; }
        }
        public NavigationHelper Navigator 
        {
            get { return navigator; }
        }
        public GroupHelper Groups
        { 
            get{ return groupHelper; }
        }
        public ContactHelper Contact
        {
            get { return contactHelper;  }
        }

       
    }
}
