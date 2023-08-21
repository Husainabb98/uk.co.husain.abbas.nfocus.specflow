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
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        //private IWebDriver _driver;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

     

        [Given(@"I am on the edgewords homepage")]
        public void GivenIAmOnTheEdgewordsHomepage()
        {
            
            
        }

        [When(@"I enter the logging information")]
        public void WhenIEnterLoggingInformation()
        {
            

            

            
        }

        [Then(@"I should be logged in")]
        public void ThenIshouldLogIn()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");
            Assert.That(wasLoginSuccessful, Is.True);
        }
    }
}


