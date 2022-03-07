using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebTests.Models;

namespace WebTests
{
    [TestClass]
    public class FormTests : TestsBase
    {
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
