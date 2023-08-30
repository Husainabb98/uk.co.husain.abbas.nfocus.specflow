using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class MyAccountPOM
    {
        private IWebDriver _driver;

        public MyAccountPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _orders => _driver.FindElement(By.LinkText("Orders"));
        private IWebElement _logout => _driver.FindElement(By.LinkText("Logout"));
     /*   public void shop() //placed this method into NavPOM
        {
            _shop.Click();
        }*/
        public void orders() 
        {
            _orders.Click();
        }
        public void logout() 
        { 
            _logout.Click();
        }
    }


}
