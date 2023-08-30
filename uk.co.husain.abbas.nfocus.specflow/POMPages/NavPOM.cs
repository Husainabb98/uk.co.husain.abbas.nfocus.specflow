using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Helpers;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class NavPOM
    {
        private IWebDriver _driver;

        public NavPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _home => _driver.FindElement(By.CssSelector("#menu-item-42 > a"));
        private IWebElement _shop => _driver.FindElement(By.CssSelector("#menu-item-43 > a"));
        private IWebElement _cart => _driver.FindElement(By.CssSelector("#menu-item-44 > a"));
        private IWebElement _checkout => _driver.FindElement(By.CssSelector("#menu-item-45 > a"));
        private IWebElement _myAcoount => _driver.FindElement(By.CssSelector("#menu-item-46 > a"));
        private IWebElement _blog => _driver.FindElement(By.CssSelector("#menu-item-47 > a"));

        public void navHome()
        {
            _home.Click();
        }

        public void navShop()
        {
            _shop.Click();
        }

        public void navCart()
        {
            _cart.Click();
        }

        public void navCheckout()
        {
            _checkout.Click();
        }

        public void navMyAccount()
        {
            try
            {
                _myAcoount.Click();
            }
            catch 
            {
                _myAcoount.Click();
            }
            
        }

        public void navBlog()
        {
            _blog.Click();
        }
    }
}