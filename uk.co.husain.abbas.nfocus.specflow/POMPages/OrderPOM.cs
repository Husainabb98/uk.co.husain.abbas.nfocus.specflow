using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class OrderPOM
    {
        private IWebDriver _driver;

        public OrderPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong"));
        private IWebElement _myAccount => _driver.FindElement(By.CssSelector("#menu-item-46 > a"));

        public string orderNumber()
        {
            return _orderNumber.Text;
        }

        public void myAccount()
        {
            _myAccount.Click();

            
        }
    }
}
