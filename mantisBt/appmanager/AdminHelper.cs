using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace mantis
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager,String baseURL) : base(manager) 
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php" ;
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tbody tr")); 
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("td")).FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData {
                    Name = name, Id = id
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
      //      Logout();
      //      IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.Name("password")).SendKeys("newPass");
            driver.FindElement(By.CssSelector("input.button")).Click();
            return driver;
        }

        public void Logout()
        {
            driver.FindElement(By.Id("logout-link")).Click();
        }
    }
}
