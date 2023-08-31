using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static uk.co.husain.abbas.nfocus.specflow.Support.Helpers;

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
        private IWebElement _orderNumber => WaitForElement(_driver, By.CssSelector(".woocommerce-order-overview__order.order > strong"),10);
        
        //method that allows the billing information to be entered
        //and is also parameterised to allow the data to be in the testing file 
        public void enterInformation(string fname, string lname, string address, 
            string city, string postcode, string phone)
        {
            _fname.Clear();
            _fname.SendKeys(fname);
            _lname.Clear();
            _lname.SendKeys(lname);
            _address.Clear();
            _address.SendKeys(address);
            _city.Clear();
            _city.SendKeys(city);
            _postcode.Clear();
            _postcode.SendKeys(postcode);
            _phone.Clear();
            _phone.SendKeys(phone);
         
            //Screenshot screenshot = _driver.TakeScreenshot(); // need to fix 
           // screenshot.SaveAsFile("C:\\Users\\HusainAbbas\\source\\repos\\Screenshot\\order.png");
        }
        public void placeOrder()
        {
            try //placed in a try catch block to prevent stale element exception 
            {
                _placeOrder.Click();
            }
            catch (StaleElementReferenceException e)
            {
                _driver.Navigate().Refresh();
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].click();", _placeOrder);
            }
        }
        public string orderNumber()
        {
            string orderNumber = _orderNumber.Text;
            return orderNumber;
        }
        public void screenshot()
        {
            Screenshot orderNumber = ((ITakesScreenshot)_orderNumber).GetScreenshot();
            orderNumber.SaveAsFile(@".\..\order_number.png");
        }
    }
}
