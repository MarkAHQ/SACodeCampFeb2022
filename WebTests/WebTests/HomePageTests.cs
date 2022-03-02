using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTests
{
    [TestClass]
    public class HomePageTests
    {
        [TestMethod]
        public void Playground_VerifyHomepage()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

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

            driver.Quit();
        }
    }
}