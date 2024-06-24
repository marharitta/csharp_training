using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    public  class TestBase
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
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
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void Logoff()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void SubmiteContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        protected void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            /*           driver.FindElement(By.Name("nickname")).Clear();
                       driver.FindElement(By.Name("nickname")).SendKeys("IvanovI");
                       driver.FindElement(By.Name("title")).Click();
                       driver.FindElement(By.Name("title")).Clear();
                       driver.FindElement(By.Name("title")).SendKeys("newTitle");
                       driver.FindElement(By.Name("company")).Clear();
                       driver.FindElement(By.Name("company")).SendKeys("IvanovCompany");
                       driver.FindElement(By.Name("address")).Clear();
                       driver.FindElement(By.Name("address")).SendKeys("newAdress");
                       driver.FindElement(By.Name("home")).Clear();
                       driver.FindElement(By.Name("home")).SendKeys("8017392847");
                       driver.FindElement(By.Name("mobile")).Clear();
                       driver.FindElement(By.Name("mobile")).SendKeys("+375292548759");
                       driver.FindElement(By.Name("work")).Clear();
                       driver.FindElement(By.Name("work")).SendKeys("+375336547892");
                       driver.FindElement(By.Name("email")).Clear();
                       driver.FindElement(By.Name("email")).SendKeys("newemail@gmail.com");
                       driver.FindElement(By.Name("email2")).Clear();
                       driver.FindElement(By.Name("email2")).SendKeys("myemail@mail.ru");
                       driver.FindElement(By.Name("bday")).Click();
                       new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("13");
                       driver.FindElement(By.Name("bmonth")).Click();
                       new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("May");
                       driver.FindElement(By.Name("byear")).Click();
                       driver.FindElement(By.Name("byear")).Clear();
                       driver.FindElement(By.Name("byear")).SendKeys("1982");
                       driver.FindElement(By.Name("aday")).Click();
                       new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("16");
                       driver.FindElement(By.Name("amonth")).Click();
                       new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("August");
                       driver.FindElement(By.Name("ayear")).Click();
                       driver.FindElement(By.Name("ayear")).Clear();
                       driver.FindElement(By.Name("ayear")).SendKeys("2010");*/
        }

        protected void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void LogIn(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void SelectGroupToDelete()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
        }
        protected void SubmitDeleteGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }
    }
}
