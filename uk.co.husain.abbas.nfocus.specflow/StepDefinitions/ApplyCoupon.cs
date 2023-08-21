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
        [Given(@"that i am logged in")]
        public void GivenThatIAmLoggedIn()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");
        }

        [When(@"I have items in cart")]
        public void WhenIHaveItemsInCart()
        {
            MyAccountPOM myAccount = new MyAccountPOM(_driver);

            myAccount.shop();
            Thread.Sleep(500);

            
        }

        [When(@"i navigate to the cart page and click apply coupon")]
        public void WhenINavigateToTheCartPageAndClickApplyCoupon()
        {
            ShopPOM shop = new ShopPOM(_driver);
            shop.addAndViewCart();
            Thread.Sleep(500);
        }

        [Then(@"the discount should be applied")]
        public void ThenTheDiscountShouldBeApplied()
        {
            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon();
            Thread.Sleep(5000);
            cart.applyCoupon();
            decimal expectedTotal = cart.retrieveExpectedTotal();
            decimal actualTotal = cart.retrieveTotal();
            Assert.That(expectedTotal, Is.EqualTo(actualTotal),
                "Didn't get the expected total");
        }
    }
}