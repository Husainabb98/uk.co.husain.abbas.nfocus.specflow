using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class CheckOutPOM
    {
        private IWebDriver _driver;

        public CheckOutPOM(IWebDriver driver)
        {
            _driver = driver;   
        }
        private IWebElement _fname => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement _lname => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement _address => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement _city => _driver.FindElement(By.Id("billing_city"));
        private IWebElement _postcode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement _phone => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement _placeOrder => _driver.FindElement(By.Id("place_order"));

        public void enterInformation()
        {
            _fname.Clear();
            _fname.SendKeys("gogog");
            _lname.Clear();
            _lname.SendKeys("gg");
            _address.Clear();
            _address.SendKeys("gogogo street");
            _city.Clear();
            _city.SendKeys("gogogog city");
            _postcode.Clear();
            _postcode.SendKeys("SW15 4JQ");
            _phone.Clear();
            _phone.SendKeys("07777777777");
            Thread.Sleep(1000);
            _placeOrder.Click();

            Thread.Sleep(1500);
            Screenshot screenshot = _driver.TakeScreenshot();
            screenshot.SaveAsFile("C:\\Users\\HusainAbbas\\source\\repos\\Screenshot\\order.png");
        }

    }
}
