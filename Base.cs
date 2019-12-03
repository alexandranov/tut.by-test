using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationTut.by
{
    public class Base
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected Base(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        protected string attribute;
        protected string text;


        static JObject json = JObject.Parse(File.ReadAllText(@"/Users/aleksandra/Documents/chromedrivers/AutomationTut.by/AutomationTut.by/JSONFile.json"));

        protected static string GetCredValue(string prop) => (string)json[prop];


        protected void SwitchPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        protected void ClickButton(string locator)
        {

            driver.FindElement(By.XPath(locator)).Click();

        }

        protected void Wait(string locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        protected void WriteText(string locator, string text)
        {

            driver.FindElement(By.XPath(locator)).SendKeys(text);
        }

        protected string GetAttribute(string locator, string attribute)
        {
            string topic = driver.FindElement(By.XPath(locator)).GetAttribute(attribute);
            return topic;
        }

    }
}
