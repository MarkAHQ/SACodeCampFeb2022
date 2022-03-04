﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Models
{
    internal class Planet
    {
        private readonly IWebElement thisElement;

        public Planet(IWebElement thisElement)
        {
            this.thisElement = thisElement;
        }

        public IWebElement ExploreButton => thisElement.FindElement(By.TagName("button"));

        public string Name => thisElement.FindElement(By.ClassName("name")).Text;

        public long Distance
        {
            get
            {
                var distanceText = thisElement.FindElement(By.ClassName("distance")).Text;
                distanceText = RemoveKms(distanceText);
                return long.Parse(distanceText, NumberStyles.AllowThousands);
            }
        }

        private static string RemoveKms(string distanceText)
        {
            return distanceText.Split(' ')[0];
        }

        internal void ClickExplore()
        {
            ExploreButton.Click();
        }
    }
}
