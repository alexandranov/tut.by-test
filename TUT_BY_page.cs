using System;
using OpenQA.Selenium;

namespace AutomationTut.by
{
    public class TUT_BY_page
    {
        private IWebDriver driver;

        public TUT_BY_page(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal protected IWebElement searhField => driver.FindElement(By.XPath("//input[@id='search_from_str']"));

        string login = "aliaksandranovikava@tut.by";
        string password = "sasha220982";
        public string loggin = "//a[@data-target-popup ='authorize-form']";
        public string login_field = "//input[@name='login']";
        public string password_field = "//input[@type='password']";

        public string enter_button = "//input[@class ='button auth__enter']";
        public string  name_button = "//span[@class ='uname']";
        public string mail_button = "//*[@id='authorize']/div/div/div/div/ul/li[2]/a";

        public void ClickOnLogginButton()
        {
            driver.FindElement(By.XPath(loggin)).Click();
        }

        public void WriteLogin()
        {
            driver.FindElement(By.XPath(login_field)).SendKeys(login);
        }

        public void WritePassword()
        {
            driver.FindElement(By.XPath(password_field)).SendKeys(password);
        }

        public void ClickOnEnterButton()
        {
            driver.FindElement(By.XPath(enter_button)).Click();
        }

        public void ClickOnNameButton()
        {
            driver.FindElement(By.XPath(name_button)).Click();
        }

        public void ClickOnMailButton()
        {
            driver.FindElement(By.XPath(mail_button)).Click();
        }

    }
}
