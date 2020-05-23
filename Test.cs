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
using System.Security.Cryptography.X509Certificates;

namespace Cas60
{
    class Test
    {
        IWebDriver driver;
        string email = "antonicmilijana@yahoo.com";
        string password = "123Vizionar123";
        [Test]
        public void TestListNumbers()
        {
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToHomePage();
            Table T;
            T= naslovna.ListOfRegistration();
            Assert.Greater(T.Countz(), 0);
        }
        [Test]
        public void CreateNewUser()
        {
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToHomePage();
            NewUser U;
            U=naslovna.CreateUser();
            U.CNewUser(email, password);
           

        }
        [Test]
        [TestCase("antonicmilijana@yahoo.com")]
        [TestCase("blablabla@yahoo.com")]
        public void VerifyUser(string email)
        {
         HomePage naslovna = new HomePage(driver);
         naslovna.GoToHomePage();
         Table T;
         T = naslovna.ListOfRegistration();
         Assert.IsTrue(T.Verify(email));

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
