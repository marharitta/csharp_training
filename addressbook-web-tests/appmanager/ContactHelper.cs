using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            ReturnToHomePage();
            AddNewContact();
            FillContactForm(contact);
            SubmiteContactCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            ReturnToHomePage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }


        public ContactHelper Remove(int v)
        {
            ReturnToHomePage();
            SelectContact(v);
            SubmitDeleteContact();
            ReturnToHomePage();
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
            contactCache = null;
            return this;
        }
       public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath($"//*[@id='maintable']/tbody/tr[{v+2}]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper SubmiteContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            contactCache = null;
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
            contactCache = null;
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
                ReturnToHomePage();

                driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[2]/td[1]/input")).Click();
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData()
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            
            return driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name='entry']")).Count();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };

        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value").Trim();
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value").Trim();
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value").Trim();
            string company = driver.FindElement(By.Name("company")).GetAttribute("value").Trim();
            string address = driver.FindElement(By.Name("address")).GetAttribute("value").Trim();
            string nick = driver.FindElement(By.Name("nickname")).GetAttribute("value").Trim();

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value").Trim();
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value").Trim();
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value").Trim();
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value").Trim();

            string email = driver.FindElement(By.Name("email")).GetAttribute("value").Trim();
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value").Trim();
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value").Trim();

            return new ContactData(firstName, lastName)
            { 
                MiddleName = middleName,
                Company = company,
                Address = address,
                Nickname = nick,
                TelephoneHome = homePhone,
                Mobile = mobilePhone,
                Telwork = workPhone,
                Fax = faxPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public string GetContactInformationFromProperty(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.XPath($"//*[@id='maintable']/tbody/tr[{index + 2}]/td[7]/a/img")).Click();

            var element = driver.FindElement(By.XPath($"//*[@id=\"content\"]"));
            string text = element.Text;

            if (text == null)
            { 
                return "";
            }

            return text; //Regex.Replace(text, "\r\n", "") ;
        }

        public string Glue(ContactData contactData, bool isFromProperty)
        {
            string text;
            if (isFromProperty == false)
            {              
                text = $"{contactData.FirstName.Trim()} {contactData.LastName.Trim()}{contactData.Address.Trim()}{contactData.AllPhones.Trim()}";
                text= Regex.Replace(text,"\r\n", "");
            }
            else
            {
                string phoneLine = contactData.GetPhonesLabel();
                string result = contactData.FirstName.Trim()
                    .Append(contactData.MiddleName)
                    .Append(contactData.LastName)
                    .AppendSafeWithNewLine(contactData.Nickname)
                    .AppendSafeWithNewLine(contactData.Company)
                    .AppendSafeWithNewLine(contactData.Address);

                if (!string.IsNullOrEmpty(phoneLine))
                {
                    result = result.AppendLine()
                        .AppendSafeWithNewLine(phoneLine);
                }

                if (!string.IsNullOrEmpty(contactData.Email))
                {
                    result = result.AppendLine()
                        .AppendSafeWithNewLine(contactData.Email);
                }

                text = result;
            }

            return text;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }
        public void SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

    }
}
