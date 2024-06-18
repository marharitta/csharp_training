using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
    {
        [TestFixture]
        public class UntitledTestCase
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

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

            [Test]
            public void TheUntitledTestCaseTest()
            {
                driver.Navigate().GoToUrl(baseURL + "addressbook/");
                driver.FindElement(By.Name("user")).Click();
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys("admin");
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys("secret");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
                driver.FindElement(By.LinkText("add new")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys("Ivan");
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys("Ivanovich");
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys("Ivanov");
                driver.FindElement(By.Name("nickname")).Clear();
                driver.FindElement(By.Name("nickname")).SendKeys("IvanovI");
                driver.FindElement(By.Name("photo")).Click();
                driver.FindElement(By.Name("photo")).Clear();
                driver.FindElement(By.Name("photo")).SendKeys("C:\\fakepath\\1-80.jpg");
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
                driver.FindElement(By.Name("theform")).Click();
                driver.FindElement(By.Name("theform")).Click();
                driver.FindElement(By.Name("aday")).Click();
                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("16");
                driver.FindElement(By.Name("amonth")).Click();
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("August");
                driver.FindElement(By.Name("ayear")).Click();
                driver.FindElement(By.Name("ayear")).Clear();
                driver.FindElement(By.Name("ayear")).SendKeys("2010");
                driver.FindElement(By.Name("theform")).Click();
                driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys("admin");
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys("secret");
            }
            private bool IsElementPresent(By by)
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

            private bool IsAlertPresent()
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

            private string CloseAlertAndGetItsText()
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
        }
    }



