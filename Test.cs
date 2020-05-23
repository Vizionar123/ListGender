using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Cas60.PageObject;



namespace Cas60
{
    class Test
    {
        IWebDriver driver;
        [Test]
        public void TestListNumbers()
        {
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToHomePage();
            Table T;
            T= naslovna.ListOfRegistration();
            Assert.Greater(T.Countz(), 0);
        }
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
