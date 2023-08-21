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

        private IWebElement _shop => _driver.FindElement(By.CssSelector("#menu-item-43 > a"));
        private IWebElement _orders => _driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders > a"));
        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr:nth-child(1) > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
        public void shop()
        {
            _shop.Click();
        }
        public string expectedOrderNumber() 
        {
            _orders.Click();
            string orderNum = _orderNumber.Text;
            orderNum = orderNum.Replace("#", "");
            return orderNum;
        }
    }


}
