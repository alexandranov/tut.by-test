using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationTut.by
{ 
    public class Tests
    {
       
        private IWebDriver driver;
      
        private WebDriverWait wait;
        public DateTime currentTime;

        [SetUp]
        public void Setup()
        {
           string baseURL = @"https://www.tut.by/";
            driver = new ChromeDriver(@"/Users/aleksandra/Documents/chromedrivers/");

           currentTime = DateTime.Now;

            driver.Navigate().GoToUrl(baseURL);
            wait = new WebDriverWait(driver, new TimeSpan(0,0,20));
            
        }

        

        [Test]
        public void Test1()
        {
            string header_logo_locator = "//a[@class= 'header-logo']";
            string search_field_locator= "//input[@id='search_from_str']";
            string search_button_locator = "//input[@name= 'search']";
            string logo = "Белорусский портал";
            string header_logo = driver.FindElement(By.XPath(header_logo_locator)).GetAttribute("title");

            driver.FindElement(By.XPath(search_field_locator)).SendKeys(header_logo);
            driver.FindElement(By.XPath(search_button_locator)).Click();
            if (header_logo.Contains(logo)) {
                Assert.Pass();
            }
        }


        [Test]
        
        public void Test3() {
          
            TUT_BY_page tut_by_page = new TUT_BY_page(driver);
            Email_page email_page = new Email_page(driver,wait);

            tut_by_page.ClickOnLogginButton();
            tut_by_page.WriteLogin();
            tut_by_page.WritePassword();
            tut_by_page.ClickOnEnterButton();
            tut_by_page.ClickOnNameButton();
            tut_by_page.ClickOnMailButton();
            
            email_page.SwitchToEmailPage();
            email_page.WaitEmailPage();
            email_page.ClickOnWriteButton();
            email_page.WaitMySelfButton();
            email_page.ClickOnMyselfButton();
            email_page.WriteTopic();
            email_page.WriteMessage();
            email_page.ClickOnSendButton();

            email_page.WaitToRefresh();
            email_page.ClickOnRefreshButton();
            email_page.ClickOnRefreshButton();
           
            email_page.WaitMessageTopic();
      
            string topic_text = email_page.GetMessageTopic();


           if (topic_text == currentTime.ToString("h:mm:ss tt"))
            {
                Assert.Pass();
            }

        }

    }
}
