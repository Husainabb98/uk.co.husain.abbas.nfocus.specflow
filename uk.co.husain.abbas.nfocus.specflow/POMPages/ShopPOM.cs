using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class ShopPOM
    {
        private IWebDriver _driver;

        public ShopPOM(IWebDriver driver)
        {
            _driver = driver;
        }

       // private IWebElement _hatItem => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-29.status-publish.last.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.woocommerce-LoopProduct-link.woocommerce-loop-product__link > img"));
        private IWebElement _addToCart => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-29.status-publish.last.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart"));
        private IWebElement _viewCart => _driver.FindElement(By.CssSelector("#site-header-cart > li:nth-child(1) > a"));

        public void addAndViewCart()
        {
            _addToCart.Click();
            _viewCart.Click();  
        }

    }
}
