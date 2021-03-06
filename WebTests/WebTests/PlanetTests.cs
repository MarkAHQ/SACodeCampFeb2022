using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using WebTests.Models;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace WebTests
{
    [TestClass]
    public class PlanetTests : TestsBase
    {
        [TestMethod]
        public void Playground_VerifyEarthExplore()
        {
            // Arrange
            new Toolbar(driver).ClickPlanets();

            // Act
            PlanetsPage planetPage = new(driver);
            Planet earth = planetPage.GetPlanet(p => p.Name == "Earth");
            earth.ClickExplore();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => new Popup(driver).Displayed);

            // Assert
            Assert.AreEqual(expected: "Exploring Earth", actual: planetPage.PopupMessage.Text);
        }

        [TestMethod]
        public void Playground_VerifyEarthDistance()
        {
            // Arrange
            new Toolbar(driver).ClickPlanets();

            // Act
            PlanetsPage planetsPage = new(driver);
            Planet foundPlanet = planetsPage.GetPlanet(p => p.Distance == 149600000);

            // Assert
            Assert.AreEqual(expected: "Earth", actual: foundPlanet.Name);
        }
    }
}
