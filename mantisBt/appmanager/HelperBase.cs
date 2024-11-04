using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantisTest
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        protected bool acceptNextAlert = true;


        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
        public bool IsElementPresent(By by)
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

        public bool IsAlertPresent()
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

        public string CloseAlertAndGetItsText()
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
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                var element = driver.FindElement(locator);
                element.Click();
                element.Clear();
                element.SendKeys(text);
            }

        }

        public void Select(By locator, string value)
        {
            if (value != null)
            {
                SelectElement dropdown = new SelectElement(driver.FindElement(locator));
                dropdown.SelectByValue(value);
            }
        }

        public void SetCheckbox(By locator, bool isChecked)
        {
            var checkBoxElement = driver.FindElement(locator);
            if (checkBoxElement.Selected != isChecked)
            {
                checkBoxElement.Click();
            }
        }
    }
}