using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace AutomationTut.by
{
    public class Email_page : Base
    {
        public DateTime currentTime = DateTime.Now;

        public Email_page(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public string writeButton = "//span[@class = 'mail-ComposeButton-Text']";
        public string emailPageElement = "//span[@class = 'mail-ComposeButton-Text']";
        public string myselfButton = "//span[@data-name='Себе']";
        public string topicField = "//input[@name='subj-cf13901edc6bd24be0c3dee0cde1ac3a3362ff06']";
        public string messageField = "//div[@id='cke_1_contents']/div/div";
        public string sendButton = "//div/button/span/span/span";
        public string refreshButton = "//span[@data-click-action='mailbox.check']";
        public string messageTopic = "//*[@id='nb-1']/body/div[2]/div[6]/div/div[3]/div[3]/div[2]/div[5]/div[1]/div/div/div[2]/div/div[1]/div/div/div/a/div/span[2]/div/span/span[1]/span[1]/span";
        public string doneMassage = "//*[text()='Письмо отправлено.']";

        public void SwitchToEmailPage()
        {
            SwitchPage();
        }

        public void ClickOnWriteButton()
        {
            ClickButton(writeButton);
        }

        public void ClickOnMyselfButton()
        {
            Wait(myselfButton);
            ClickButton(myselfButton);
        }
        public void ClickOnSendButton()
        {
            ClickButton(sendButton);
        }

        public void ClickOnRefreshButton()
        {
            Wait(doneMassage);
            ClickButton(refreshButton);
        }

        public void WaitEmailPage()
        {
            Wait(emailPageElement);
        }

        public void WriteMessage()
        {
            text = "Message";
            WriteText(messageField, text);
        }

        public void WriteTopic()
        {
            text = currentTime.ToString("h:mm:ss tt");
            WriteText(topicField, text);
        }

        public string GetMessageTopic()
        {
            Wait(messageTopic);
            attribute = "title";
            string topic = GetAttribute(messageTopic, attribute);
            return topic;
        }

    }
}
