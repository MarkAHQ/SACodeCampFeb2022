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

        public bool Displayed => element.Displayed;

        public string Text => element.FindElement(By.ClassName("popup-message")).Text;
    }
}
