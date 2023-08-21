using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class HomePagePOM
    {
        private IWebDriver _driver;  

        public HomePagePOM(IWebDriver driver) 
        {
            this._driver = driver; 
        }
        
        private IWebElement _loginLink => _driver.FindElement(By.Id("password"));

        public void GoLogin()
        {
            _loginLink.SendKeys(Keys.Enter);
        }
    }
}
