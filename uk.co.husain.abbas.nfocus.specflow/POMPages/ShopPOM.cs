using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Helpers;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class ShopPOM
    {
        private IWebDriver _driver;
        // creating a varible to make a locator more dynamic 
        private string _item;

        public ShopPOM(IWebDriver driver)
        {
            _driver = driver;
        }

      
        private IWebElement _addToCart => _driver.FindElement(By.CssSelector($"[aria-label=\"Add “{_item}” to your cart\"]"));
        private IWebElement _viewCart => WaitForElement(_driver, By.CssSelector("[title='View cart']"));

        //method that item into cart and also takes a parameter so we can soft code the item
        public void addToCart(string itemSelected)
        {
            _item = itemSelected;
            _addToCart.Click();
              
        }
        //method that clicks the view cart method
        public void viewCart()
        {
            _viewCart.Click();
        }

    }
}
