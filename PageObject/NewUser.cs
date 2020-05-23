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

namespace Cas60.PageObject
{
    class NewUser
    {private IWebDriver driver;
     private  WebDriverWait wait;
     public NewUser(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
     public void CNewUser(string email, string password)
        {
         IWebElement button = this.driver.FindElement(By.XPath("//input[@type='submit']"));
            if (button.Enabled)
            {
                IWebElement name = this.driver.FindElement(By.Name("ime"));
                if (name.Enabled)
                {
                    name.SendKeys("Milijana");
                }
                IWebElement prezime = this.driver.FindElement(By.Name("prezime"));
                if (prezime.Enabled)
                {
                    prezime.SendKeys("Antonic");
                }
                IWebElement korisnicko = this.driver.FindElement(By.Name("korisnicko"));
                if (korisnicko.Enabled)
                {
                    korisnicko.SendKeys(password);
                }
                IWebElement Eemail = this.driver.FindElement(By.Name("email"));
                if (Eemail.Enabled)
                {
                   Eemail.SendKeys(email);
                }
                IWebElement telefon = this.driver.FindElement(By.Name("telefon"));
                if (telefon.Enabled)
                {
                    telefon.SendKeys("33333333");
                }
                IWebElement zemlja = this.driver.FindElement(By.Name("zemlja"));
                if(zemlja.Enabled)
                {
                    SelectElement Z = new SelectElement(zemlja);
                    Z.SelectByValue("ita");
                }
                IWebElement grad = wait.Until(EC.ElementIsVisible(By.Name("grad")));
                if(grad.Enabled)
                {
                    SelectElement G = new SelectElement(grad);
                    G.SelectByValue("Bologna");
                }
                IWebElement adresa = this.driver.FindElement(By.XPath("//select[@name='grad']//following::input[1]"));
                if (adresa.Enabled)
                {
                    adresa.SendKeys("Nuova");
                }

                IWebElement pol = this.driver.FindElement(By.XPath("//input[@id='pol_z']"));
                if (pol.Enabled)
                {
                    pol.Click();
                }
                System.Threading.Thread.Sleep(3000);
                button.Click();
            }


        }

    }
}
