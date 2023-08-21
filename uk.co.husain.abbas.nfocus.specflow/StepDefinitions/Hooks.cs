using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.specflow.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        

        public static IWebDriver _driver;



        [Before]

        public void SetUp()

        {

            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            _driver.FindElement(By.CssSelector("body > p > a")).Click();

        }

        [After]

        public void TearDown()

        {

            Thread.Sleep(2000); //So we can see what's going on

            _driver.Quit();

        }
    }
}
