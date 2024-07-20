using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class NavigationHelper: HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public NavigationHelper GoToGroupsPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return this;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public NavigationHelper OpenHomePage()
        {
            if(driver.Url == baseURL + "addressbook/") 
            { 
                return this; 
            }
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
            return this;
        }
    }
}
