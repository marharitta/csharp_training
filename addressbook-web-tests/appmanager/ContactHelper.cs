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
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            ReturnToHomePage();
            AddNewContact();
            FillContactForm(contact);
            SubmiteContactCreation();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            ReturnToHomePage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }


        public ContactHelper Remove(string v)
        {
            ReturnToHomePage();
            SelectContact(v);
            SubmitDeleteContact();

            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
       public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath($"(//img[@alt='Edit'])[{v}]")).Click();
            return this;
        }
        public ContactHelper SubmiteContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.TelephoneHome);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Telwork);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("homepage"), contact.HomePage);

            return this;
        }
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitDeleteContact()
        {
            driver.FindElement(By.XPath($"//*[@id=\"content\"]/form[2]/div[2]/input")).Click();
            return this;
        }

        public ContactHelper SelectContact(string v)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{v}]/td/input")).Click();
            return this;
        }

    }
}
