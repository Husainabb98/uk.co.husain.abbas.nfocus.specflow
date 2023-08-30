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
       
        private IWebElement _expectedOrderNumber => _driver.FindElement(By.CssSelector(" tr:nth-child(1) >[data-title=\"Order\"] >  a"));
        public string expectedOrderNumber()
        {
            string orderNum = _expectedOrderNumber.Text;
            orderNum = orderNum.Replace("#", "");
            return orderNum;
        }
    }
}
