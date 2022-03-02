using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebTests
{
    [TestClass]
    public class HomePageTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Playground_VerifyHomepage()
        {
            var headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;
            foreach (var headerElement in headerElements)
            {
                if (headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    break;
                }
            }

            Assert.IsTrue(foundHeader.Displayed);
        }

        [TestMethod]
        public void Playground_VerifySubmitButton()
        {
            const string Name = "Mark";
            //Arrange

            // Act
            driver.FindElement(By.Id("forename")).SendKeys(Name);
            driver.FindElement(By.Id("submit")).Click();

            // Assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IWebElement popupElement = driver.FindElement(By.ClassName("popup-message"));
            wait.Until(d => popupElement.Displayed);

            Assert.AreEqual(expected: $"Hello {Name}", actual: popupElement.Text);
        }
    }
}