using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace WebTests
{
    [TestClass]
    public class HomePageTests : TestsBase
    {
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
            Assert.AreEqual(expected: $"Hello {Name}", actual: homePage.PopupMessage.Text);
        }
    }
}