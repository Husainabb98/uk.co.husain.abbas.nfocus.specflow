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
    public class OrderNumber
    {
        private readonly ScenarioContext _scenarioContext;

        public OrderNumber(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I have proceeded to checkout")]
        public void GivenIHaveProceededToCheckout()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");

            MyAccountPOM myAccount = new MyAccountPOM(_driver);

            myAccount.shop();


            ShopPOM shop = new ShopPOM(_driver);
            shop.addAndViewCart();

            CartPOM cart = new CartPOM(_driver);
            cart.enterCoupon();
            cart.applyCoupon();
            cart.proceedToCheckOut();
        }

        [When(@"I when i billing information and i place order")]
        public void WhenIWhenIBillingInformationAndIPlaceOrder()
        {
            CheckOutPOM check = new CheckOutPOM(_driver);
            check.enterInformation();
        }

        [When(@"I navigate to my account and view orders")]
        public void WhenINavigateToMyAccountAndViewOrders()
        {
            
        }

        [Then(@"order number should same")]
        public void ThenOrderNumberShouldSame()
        {
            OrderPOM order = new OrderPOM(_driver);
            string actualOrderNumber = order.orderNumber();
            order.myAccount();
            MyAccountPOM myAccount = new MyAccountPOM(_driver);
            string expectedOrderNumber = myAccount.expectedOrderNumber();

            Thread.Sleep(1000);
            Assert.That(expectedOrderNumber, Is.EqualTo(actualOrderNumber),
               "Didn't get the expected order number");
        }
    }
}

