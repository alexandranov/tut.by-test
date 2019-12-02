using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTut.by
{
    public class TUT_BY_page : Base
    {
        public TUT_BY_page(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {

        }

        public string baseURL = @"https://www.tut.by/";
        public string headerLogoLocator = "//a[@class= 'header-logo']";
        public string searchFieldLocator = "//input[@id='search_from_str']";
        public string searchButtonLocator = "//input[@name= 'search']";
        public string logo = "Белорусский портал";
        public string loggin = "//a[@data-target-popup ='authorize-form']";
        public string loginField = "//input[@name='login']";
        public string passwordField = "//input[@type='password']";
        public string enterButton = "//input[@value ='Войти']";
        public string nameButton = "//span[@class ='uname']";
        public string mailButton = "//*[@id='authorize']/div/div/div/div/ul/li[2]/a";
       
        string login = GetCredValue("login");
        string password = GetCredValue("password");

        public void ClickOnLogginButton()
        {
            ClickButton(loggin);
        }

        public void WriteLogin()
        {
            WriteText(loginField, login);
        }

        public void WritePassword()
        {
            WriteText(passwordField, password);
        }

        public void ClickOnEnterButton()
        {
            ClickButton(enterButton);
        }

        public void ClickOnNameButton()
        {
            ClickButton(nameButton);
        }

        public void ClickOnMailButton()
        {
            ClickButton(mailButton);
        }

    }
}
