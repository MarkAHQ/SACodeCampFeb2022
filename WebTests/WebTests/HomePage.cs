using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IWebElement PopupMessage => driver.FindElement(By.ClassName("popup-message"));

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => PopupMessage.Displayed);
        }
    }
}
