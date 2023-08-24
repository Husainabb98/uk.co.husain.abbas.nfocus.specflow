﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Helpers;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class CartPOM
    {
        private IWebDriver _driver;

        public CartPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _coupon => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement _applyCoupon => _driver.FindElement(By.CssSelector("button[name='apply_coupon']"));
        private IWebElement _total => _driver.FindElement(By.CssSelector(".order-total > td bdi"));
        private IWebElement _subTotal => _driver.FindElement(By.CssSelector(".cart-subtotal bdi"));
        private IWebElement _proceedToCheckout => _driver.FindElement(By.CssSelector(".checkout-button"));
        private IWebElement _discount => _driver.FindElement(By.CssSelector(".cart-discount > td > .amount.woocommerce-Price-amount"));
        private IWebElement _clearItem => WaitForElement(_driver, By.CssSelector(".remove"), 10);
        //method that takes a parameter so we can soft code the coupon and also scrolls down the page
        public void enterCoupon(string discount)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0,1450)", "");
            _coupon.SendKeys(discount);
            Thread.Sleep(500);
            
        }
        //method that clicks on the apply coupon button
        public void applyCoupon()
        {
            _applyCoupon.Click();

        }
        //method that clears the items in cart, put in a try catch block to prevent stale element exception
        public void clearItem()
        {
            try
            {
                _clearItem.Click();
            }
            catch 
            {
                _clearItem.Click();
            }
            
        }
        //method that calculates the expected total price
        public decimal retrieveExpectedTotal()
        {
            string total = _total.Text;
            total = total.Replace("£", "");
            string subTotal = _subTotal.Text;
            subTotal = subTotal.Replace("£", "");
            string discount = _discount.Text;
            discount = discount.Replace("£", "");
            decimal total1 = Convert.ToDecimal(total);
            decimal subTotal1 = Convert.ToDecimal(subTotal);
            decimal discount1 = Convert.ToDecimal(discount);
            decimal expectedTotal = subTotal1 *0.85m + 3.95m;
            return expectedTotal;
        }
        //method that return the total price
        public decimal retrieveTotal() 
        {
            string total = _subTotal.Text;
            total = total.Replace("£", "");
            decimal total1 = Convert.ToDecimal(total);
            return total1;


        }
        //method that clicks on the proceed to checkout button and also scrolls down the page
        public void proceedToCheckOut()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0,1450)", "");
            _proceedToCheckout.Click();
        }
    }
}
