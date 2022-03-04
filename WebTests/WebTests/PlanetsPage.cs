using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebTests.MatchingStrategies;
using WebTests.Models;

namespace WebTests
{
    internal class PlanetsPage
    {
        private IWebDriver driver;

        public PlanetsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Popup PopupMessage => new Popup(driver);

        private IEnumerable<Planet> GetPlanets()
        {
            var allPlanets = driver.FindElements(By.ClassName("planet"));

            foreach (var planet in allPlanets)
            {
               yield return new Planet(planet);
            }
        }

        internal Planet GetPlanet(Predicate<Planet> matchStrategy)
        {
            foreach (var planet in GetPlanets())
            {
                if (matchStrategy.Invoke(planet))
                {
                    return planet;
                }
            }

            throw new NotFoundException($"Could not find planet.");
        }
    }
}