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
    class Table
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Table(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }
        public ReadOnlyCollection<IWebElement> ListGender
        {
            get
            {
                ReadOnlyCollection<IWebElement> LG;
                try
                {
                    LG=this.driver.FindElements(By.XPath("//table//td[@class='gender']"));

                }
                catch(Exception)
                {
                    LG = null;
                }
                return LG;
            }
         
        }
        public UInt64 Countz()
        {
            UInt64 S=0;
            foreach(IWebElement L in this.ListGender)
            {
                if (L.Text == "Z") { S = S + 1; }
            }
            return S;
        }

    }
}
