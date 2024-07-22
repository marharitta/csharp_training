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


        public ContactHelper Remove(int v)
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
            if (IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == true)
            {
                driver.FindElement(By.XPath($"(//img[@alt='Edit'])[{v}]")).Click();
            }
            else
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";
                Create(contact);

                driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[1]/td/input")).Click();
            }
            
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

        public ContactHelper SelectContact(int v)
        {
            
            
            if (IsElementPresent(By.XPath($"//*[@id='maintable']/tbody/tr[2]")) == true)
            {
                driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{v+2}]/td/input")).Click();
            }
            else
            {
                ContactData contact = new ContactData();
                contact.FirstName = "Petr";
                contact.LastName = "Petrov";
                Create(contact);

                driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[1]/td/input")).Click();
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = element.FindElement(By.XPath("td[2]")).Text
                });
            }
            return contacts;
        }
    }
}
