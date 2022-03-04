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
                return GetToolbarButton("forms");
            }
        }

        IWebElement PlanetButton
        {
            get
            {
                return GetToolbarButton("planets");
            }
        }

        private IWebElement GetToolbarButton(string buttonName)
        {
            return driver.FindElement(By.ClassName("hidden-sm-and-down"))
                         .FindElement(By.CssSelector($"[aria-label={buttonName}]"));
        }

        internal void ClickFormButton()
        {
            FormButton.Click();
        }


        internal void ClickPlanets()
        {
            PlanetButton.Click();
        }
    }
}