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
        public void GivenThatTheUserIsLoggedIn()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");
        }

        [Given(@"the user has '([^']*)' in the cart")]
        public void GivenTheUserHasInTheCart(string item)
        {
            MyAccountPOM myAccount = new MyAccountPOM(_driver);

            myAccount.shop();
            Thread.Sleep(500);

            ShopPOM shop = new ShopPOM(_driver);
            shop.addToCart(item);
            shop.viewCart();

        }



        [When(@"the user applies the coupon '([^']*)'")]
        public void WhenTheUserAppliesTheCoupon(string discount)
        {
            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon(discount);
            cart.applyCoupon();
        }


        [Then(@"the discount '([^']*)'% should be applied")]
        public void ThenTheDiscountShouldBeApplied(decimal discount)
        {
            CartPOM cart = new CartPOM(_driver);
           
            Assert.That(cart.retrieveExpectedTotal(), Is.EqualTo(cart.retrieveTotal() *((100m-discount)/100m) +3.95m),
                $"Coupon doesn't take off {discount}%");
            cart.clearItem();
        }
    }
}