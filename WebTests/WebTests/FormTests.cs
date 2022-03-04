using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests
{
    [TestClass]
    public class FormTests
    {
        IWebDriver driver;

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
        public void Playground_VerifyFeedback()
        {
            // Arrange
            new Toolbar(driver).ClickFormButton();

            // Act
            var formSheet = new ModernSheet(driver);
            formSheet.SetName("Mark");
            formSheet.SetEmail("mark.arnold@accesshq.com");
            formSheet.SetState(State.QLD);
            formSheet.ClickAgree();
            formSheet.ClickSubmit();

            // Assert
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                d => formSheet.PopupElement.Text != string.Empty);
            Assert.AreEqual(expected: "Thanks for your feedback Mark", actual: formSheet.PopupElement.Text);
        }
    }
}
