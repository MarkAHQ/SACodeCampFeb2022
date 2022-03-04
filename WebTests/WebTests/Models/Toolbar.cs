using OpenQA.Selenium;

namespace WebTests.Models
{
    internal class Toolbar
    {
        private IWebDriver driver;

        public Toolbar(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement FormButton
        {
            get
            {
                return driver.FindElement(By.ClassName("hidden-sm-and-down"))
                             .FindElement(By.CssSelector("[aria-label=forms]"));
            }
        }

        internal void ClickFormButton()
        {
            FormButton.Click();
        }
    }
}