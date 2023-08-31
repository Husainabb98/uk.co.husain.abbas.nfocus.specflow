using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.specflow.Support
{
    internal static class Helpers
    {

        public static IWebElement WaitForElement(IWebDriver driver, By Locator, int TimeInSeconds = 5)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeInSeconds));
            explicitWait.Until(element => element.FindElement(Locator).Displayed);
            return driver.FindElement(Locator);
        }
    }
}