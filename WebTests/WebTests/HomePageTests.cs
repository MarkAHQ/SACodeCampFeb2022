using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            var homePage = new HomePage(driver);

            Assert.IsTrue(homePage.GetHeaderCalled("Web Playground").Displayed);
        }

        [TestMethod]
        public void Playground_VerifySubmitButton()
        {
            //Arrange
            const string Name = "Mark";
            var homePage = new HomePage(driver);

            // Act
            homePage.SubmitForename(Name);

            // Assert
            Assert.AreEqual(expected: $"Hello {Name}", actual: homePage.PopupElement.Text);
        }
    }
}