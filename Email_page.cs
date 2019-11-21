using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTut.by
{
    public class Email_page
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private DateTime currentTime = DateTime.Now;

        public Email_page(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public string write_button = "//span[@class = 'mail-ComposeButton-Text']";
        public string email_page_element = "//span[@class = 'mail-ComposeButton-Text']";
        public string myself_button = "//span[@data-name='Себе']";
        public string topic_field = "//input[@name='subj-cf13901edc6bd24be0c3dee0cde1ac3a3362ff06']";
        public string message_field= "//div[@id='cke_1_contents']/div/div";
        public string send_button = "//div/button/span/span/span";
        public string refresh_button = "//*[@id='nb-1']/body/div[2]/div[6]/div/div[3]/div[2]/div[2]/div/div/span";
        public string message_topic = "//*[@id='nb-1']/body/div[2]/div[6]/div/div[3]/div[3]/div[2]/div[5]/div[1]/div/div/div[2]/div/div[1]/div/div/div/a/div/span[2]/div/span/span[1]/span[1]/span";
        public string done_massage = "//div[class='mail-Done js-done']";
        public void SwitchToEmailPage() {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void ClickOnWriteButton(){
            driver.FindElement(By.XPath(write_button)).Click();
        }

        public void ClickOnMyselfButton()
        {
            driver.FindElement(By.XPath(myself_button)).Click();
        }
        public void ClickOnSendButton()
        {
            driver.FindElement(By.XPath(send_button)).Click();
        }

        public void ClickOnRefreshButton()
        {
            driver.FindElement(By.XPath(refresh_button)).Click();
        }

        public void WaitEmailPage() {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(email_page_element)));
        }

        public void WaitMySelfButton() {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(myself_button)));
        }

        public void WaitToRefresh()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(refresh_button)));
        }

        public void WaitMessageTopic()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(message_topic)));
        }

        public void WriteMessage() {
            driver.FindElement(By.XPath(message_field)).SendKeys("Message");

        }

        public void WriteTopic() {
            driver.FindElement(By.XPath(topic_field)).SendKeys(currentTime.ToString("h:mm:ss tt"));
        }

        public string GetMessageTopic() {
            
           string topic =  driver.FindElement(By.XPath(message_topic)).GetAttribute("title");
           return topic;
        }

    }
}
