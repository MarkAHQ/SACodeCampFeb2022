using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Models
{
    internal class Popup
    {
        private IWebDriver driver;

        public Popup(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement element => driver.FindElement(By.ClassName("popup"));

        private IWebElement popupTextElement => element.FindElement(By.ClassName("popup-message"));

        public bool Displayed => popupTextElement.Displayed;

        public string Text => popupTextElement.Text;
    }
}