using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]
namespace WebTests
{
    [TestClass]
    public class TestsBase
    {
        protected IWebDriver driver;

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";
        }
    }
}