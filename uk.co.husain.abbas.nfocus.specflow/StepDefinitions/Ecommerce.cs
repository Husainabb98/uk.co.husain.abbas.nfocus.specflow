using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.husain.abbas.nfocus.POMPages;
using uk.co.husain.abbas.nfocus.specflow.Support;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Hooks;

namespace uk.co.husain.abbas.nfocus.specflow.StepDefinitions
{
  
    [Binding]
    public class Ecommerce
    {
        private readonly ScenarioContext _scenarioContext;

        public Ecommerce(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        //method that logs in for all test within the feature file
        [Given(@"that the user is logged in with correct credentials '([^']*)' and '([^']*)'")]
        public void GivenThatTheUserIsLoggedInWithCorrectCredentialsAnd(string username, string password)
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials(username, password);
        }
        //[Test1]
        //method that navigates to shop webpage, adds an item to cart and then views cart
        [Given(@"the user has '([^']*)' in the cart")]
        public void GivenTheUserHasInTheCart(string item)
        {
            NavPOM nav = new NavPOM(_driver);
            nav.navShop();
            ShopPOM shop = new ShopPOM(_driver);
            shop.addToCart(item);
            shop.viewCart();
        }
        //method that enters and applies coupon
        [When(@"the user applies the coupon '([^']*)'")]
        public void WhenTheUserAppliesTheCoupon(string discount)
        {
            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon(discount);
            cart.applyCoupon();
            _scenarioContext["ExpectedTotal"] = cart.retrieveExpectedTotal();
        }
        //method that verifies that discount applied from the coupon is correct
        [Then(@"the discount '([^']*)'% should be applied")]
        public void ThenTheDiscountShouldBeApplied(decimal discount)
        {
            //in case the assert fails, the test will still clear the cart
            try
            {
                CartPOM cart = new CartPOM(_driver);
                Assert.That((decimal)_scenarioContext["ExpectedTotal"], Is.EqualTo(cart.retrieveTotal() * ((100m - discount) / 100m) + 3.95m),
                    $"Coupon doesn't take off {discount}%");
                cart.clearItem();
            }
            catch
            {
                CartPOM cart = new CartPOM(_driver);
                cart.clearItem();
            }
        }
        //[Test2]
        //method navigates to shop, add items to cart, navigate to cart,
        //apply coupon and proceeds to checkout
        [Given(@"the user has proceeded to checkout with items in cart")]
        public void GivenTheUserHasProceededToCheckoutWithItemsInCart()
        {
            
            NavPOM nav = new NavPOM(_driver);
            nav.navShop();
            ShopPOM shop = new ShopPOM(_driver);
            shop.addToCart("Cap");
            shop.viewCart();
            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon("edgewords"); 
            cart.applyCoupon();
            cart.proceedToCheckOut();
        }
        //method that enters billing information and then places an order 
        [When(@"the user enters billing information and places order")]
        public void WhenTheUserEntersBillingInformationAndPlacesOrder(Table table)
        {
            CheckOutPOM check = new CheckOutPOM(_driver);
            var dTable = Support.TableExtensions.DT(table);
            foreach (DataRow r in dTable.Rows)
            {
                check.enterInformation(r.ItemArray[0].ToString(), r.ItemArray[1].ToString(), r.ItemArray[2].ToString(), r.ItemArray[3].ToString(), r.ItemArray[4].ToString(), r.ItemArray[5].ToString());
            }
            check.placeOrder();
            
        }
        //method that navigates to the orders on the my account page
        [Then(@"the user is given an order number")]
        public void ThenTheUserIsGivenAnOrderNumber()
        {
            CheckOutPOM check = new CheckOutPOM(_driver);
            _scenarioContext["orderNumber"] = check.orderNumber();
            check.screenshot();
            NavPOM nav = new NavPOM(_driver);
            nav.navMyAccount();
            MyAccountPOM account = new MyAccountPOM(_driver);
            account.orders();
        }
        //method that verifies that the order number received from place order and
        //the order number from the order page are the same
        [Then(@"the order number should appear in order history")]
        public void ThenTheOrderNumberShouldAppearInOrderHistory()
        {
            OrderPOM order = new OrderPOM(_driver);
            string expectedOrderNumber = order.expectedOrderNumber();
            NavPOM nav = new NavPOM(_driver);
            Assert.That(expectedOrderNumber, Is.EqualTo((string)_scenarioContext["orderNumber"]),
               "Didn't get the expected order number");
            MyAccountPOM myAccount = new MyAccountPOM(_driver);
            myAccount.logout();
        }
    }
}