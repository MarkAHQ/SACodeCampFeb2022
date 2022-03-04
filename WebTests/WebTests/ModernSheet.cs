using OpenQA.Selenium;
using WebTests.Models;

namespace WebTests
{
    internal class ModernSheet
    {
        private IWebDriver driver;

        public ModernSheet(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement Name => driver.FindElement(By.Id("name"));

        IWebElement StateDropDown => driver.FindElement(By.Id("state"));

        public Popup PopupElement => new(driver);

        public IWebElement Email => driver.FindElement(By.Id("email"));

        public IWebElement AgreeCheckbox => driver.FindElement(By.CssSelector("label[for=agree]"));

        internal void SetName(string name)
        {
            Name.SendKeys(name);
        }

        internal void SetEmail(string email)
        {
            Email.SendKeys(email);
        }

        internal void SetState(State state)
        {
            SelectState(state);
        }

        private void SelectState(State state)
        {
            StateDropDown.SendKeys(state.ToString());
        }

        internal void ClickAgree()
        {
            AgreeCheckbox.Click();
        }

        internal void ClickSubmit()
        {
            foreach (var button in driver.FindElements(By.TagName("button")))
            {
                if (button.Text.ToUpper() == "SUBMIT")
                {
                    button.Click();
                    break;
                }
            }
        }
    }
}