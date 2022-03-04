using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebTests.Models;

namespace WebTests
{
    internal class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));
        public IWebElement ForenameInput => driver.FindElement(By.Id("forename"));
        public Popup PopupMessage => new(driver);
        public Toolbar Toolbar => new(driver);

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => PopupMessage.Displayed);
        }

        internal IWebElement GetHeaderCalled(string headerName)
        {
            foreach (var header in driver.FindElements(By.TagName("h1")))
            {
                if (header.Text == headerName)
                {
                    return header;
                }
            }

            throw new NotFoundException($"No such header called {headerName}");
        }

        internal void SubmitForename(string name)
        {
            ForenameInput.SendKeys(name);
            SubmitButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => PopupMessage.Displayed);
        }
    }
}
