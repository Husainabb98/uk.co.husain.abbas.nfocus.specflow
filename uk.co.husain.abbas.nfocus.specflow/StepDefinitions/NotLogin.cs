using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using static uk.co.husain.abbas.nfocus.specflow.StepDefinitions.Hooks;
using uk.co.husain.abbas.nfocus.POMPages;
using OpenQA.Selenium.DevTools;

namespace uk.co.husain.abbas.nfocus.specflow.StepDefinitions
{
    [Binding]
    public class NotLogin
    {
        private readonly ScenarioContext _scenarioContext;
        //private IWebDriver _driver;

        public NotLogin(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [Given(@"I am on the edgewords homepage")]
        public void GivenIAmOnTheEdgewordsHomepage()
        {


        }

        [When(@"I enter the wrong logging information")]
        public void WhenIEnterTheWrongLoggingInformation()
        {





        }

        [Then(@"I should not be logged in")]
        public void ThenIShouldNotLogIn()
        {
            LoginPagePOM login1 = new LoginPagePOM(_driver);
            
            bool didLoginFail = login1.AttemptLoginWithInvalidDetails("asdfhasdf", "zsdfhszfdh");
            Assert.That(didLoginFail, Is.True);
        }
    }
}