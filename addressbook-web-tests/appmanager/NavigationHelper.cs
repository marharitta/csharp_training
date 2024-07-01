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
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }
    }
}
