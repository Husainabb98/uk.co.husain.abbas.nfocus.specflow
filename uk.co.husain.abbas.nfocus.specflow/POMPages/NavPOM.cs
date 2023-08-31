using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.husain.abbas.nfocus.specflow.Support.Helpers;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class NavPOM
    {
        private IWebDriver _driver;

        public NavPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _home => _driver.FindElement(By.LinkText("Home"));
        private IWebElement _shop => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement _cart => _driver.FindElement(By.LinkText("Cart"));
        private IWebElement _checkout => _driver.FindElement(By.LinkText("Checkout"));
        private IWebElement _myAcoount => _driver.FindElement(By.LinkText("My account"));
        private IWebElement _blog => _driver.FindElement(By.LinkText("blog"));

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
                Console.WriteLine("not stale element");
            }
            catch 
            {
                _myAcoount.Click();
                Console.WriteLine("stale element exception");
            }
            
        }

        public void navBlog()
        {
            _blog.Click();
        }
    }
}