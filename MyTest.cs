using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace AutomationTut.by
{
    public class Tests
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        

        [SetUp]
        public void Setup()
        {
            TUT_BY_page tut_by_page = new TUT_BY_page(driver,wait);
            driver = new ChromeDriver(@"/Users/aleksandra/Documents/chromedrivers/");
            driver.Navigate().GoToUrl(tut_by_page.baseURL);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));

        }


        [Test(Description ="Verifying Search and Logo")]
        public void Test1()
        {
            TUT_BY_page tutByPage = new TUT_BY_page(driver,wait);
   
            string headerLogo = driver.FindElement(By.XPath(tutByPage.headerLogoLocator)).GetAttribute("title");
            driver.FindElement(By.XPath(tutByPage.searchFieldLocator)).SendKeys(headerLogo);
            driver.FindElement(By.XPath(tutByPage.searchButtonLocator)).Click();
            headerLogo.Should().Contain(tutByPage.logo);
           
        }


        [Test(Description = "Verifying loggin on Tut.by page and sending masseges")]
        public void Test3()
        {

            TUT_BY_page tutByPage = new TUT_BY_page(driver,wait);
            Email_page emailPage = new Email_page(driver, wait);

            tutByPage.ClickOnLogginButton();
            tutByPage.WriteLogin(); 
            tutByPage.WritePassword();
            tutByPage.ClickOnEnterButton();
            tutByPage.ClickOnNameButton();
            tutByPage.ClickOnMailButton();

            emailPage.SwitchToEmailPage();
            emailPage.WaitEmailPage();
            emailPage.ClickOnWriteButton();
          
            emailPage.ClickOnMyselfButton();
            emailPage.WriteTopic();
            emailPage.WriteMessage();
            emailPage.ClickOnSendButton();

            emailPage.ClickOnRefreshButton();
            
           string topicText = emailPage.GetMessageTopic();
           if (topicText == emailPage.currentTime.ToString("h:mm:ss tt"))
            {
                Assert.Pass();
            }

        }

    }
}
