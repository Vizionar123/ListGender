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
using System.Security.Cryptography.X509Certificates;

namespace Cas60.PageObject
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        public void GoToHomePage()
        {

            this.driver.Navigate().GoToUrl("http://test.qa.rs/");
        }
       public IWebElement Find
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[text()='Izlistaj sve korisnike']"));
                }
                catch(Exception)
               {
                   element = null;
               }
               
                return element;

            }

        }
        public IWebElement Create
        {
            get
            {
                IWebElement element;
                try
                {
                    element = wait.Until(EC.ElementIsVisible(By.XPath("//a[text()='Kreiraj novog korisnika']")));
                }
                catch (Exception)
                { element = null; }
                return element;
            }
        }
        public NewUser CreateUser()
        {
            this.Create?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[text()='QA.rs']")));
            return new NewUser(this.driver);
        }
        public Table ListOfRegistration()
        {
           
           this.Find?.Click();
            //System.Threading.Thread.Sleep(2000);
            wait.Until(EC.ElementIsVisible(By.TagName("table")));
            return new Table(this.driver);
           

        }
        
    }
}
