using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }
        public void SubmiteContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        public void FillContactForm(ContactData contact)
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
        public void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }


    }
}
