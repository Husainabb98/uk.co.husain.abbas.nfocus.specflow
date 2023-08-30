using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.husain.abbas.nfocus.POMPages;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Hooks;

namespace uk.co.husain.abbas.nfocus.specflow.StepDefinitions
{
  
    [Binding]
    public class ApplyCoupon
    {
        private readonly ScenarioContext _scenarioContext;

        public ApplyCoupon(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"that the user is logged in")]
        //method that logs into the website
        public void GivenThatTheUserIsLoggedIn()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");
        }
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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        //method that verifies that discount applied from the coupon is correct
        [Then(@"the discount '([^']*)'% should be applied")]
        public void ThenTheDiscountShouldBeApplied(decimal discount)
        {
            CartPOM cart = new CartPOM(_driver);
            Assert.That(cart.retrieveExpectedTotal(), Is.EqualTo(cart.retrieveTotal() *((100m-discount)/100m) +3.95m),
                $"Coupon doesn't take off {discount}%");
            cart.clearItem();
        }
        //method that logs in, navigates to shop, add items to cart, navigate to cart,
        //apply coupon and proceeds to checkout
        [Given(@"the user has proceeded to checkout")]
        public void GivenTheUserHasProceededToCheckout()
        {
            /*LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");*/
            NavPOM nav = new NavPOM(_driver);
            nav.navShop();
            ShopPOM shop = new ShopPOM(_driver);
            shop.addToCart("Cap");
            shop.viewCart();
            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon("edgewords"); //need to fix
            cart.applyCoupon();
            cart.proceedToCheckOut();
        }
        //method that enters billing information and then places an order 
        [When(@"the user enters billing information and places order")]
        public void WhenTheUserEntersBillingInformationAndPlacesOrder()
        {
            CheckOutPOM check = new CheckOutPOM(_driver);
            check.enterInformation("go", "gg", "gogogo street", "gogogog city", "SW15 4JQ", "07777777777");
            check.placeOrder();
            _scenarioContext["orderNumber"] = check.orderNumber();
            check.screenshot();
        }
        //method that navigates to the orders on the my account page
        [When(@"the user navigates to my account and view orders")]
        public void WhenTheUserNavigatesToMyAccountAndViewOrders()
        {
            NavPOM nav = new NavPOM(_driver);
            nav.navMyAccount();
            MyAccountPOM account = new MyAccountPOM(_driver);
            account.orders();
        }
        //method that verifies that the order number received from place order and
        //the order number from the order page are the same
        [Then(@"the order number should be the same")]
        public void ThenTheOrderNumberShouldBeTheSame()
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