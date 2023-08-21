using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class LoginPagePOM
    {
        private IWebDriver _driver;

        public LoginPagePOM(IWebDriver driver)
        {
            _driver = driver;
            Assert.That(driver.Url, Does.Contain("demo-site/my-account/"));
        }
        private IWebElement _usernameField => _driver.FindElement(By.Id("username"));
        private IWebElement _passwordField => _driver.FindElement(By.Id("password"));
        private IWebElement _loginButton => _driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));

        public LoginPagePOM SetUsername(string username)
        {
            _usernameField.Clear();
            _usernameField.SendKeys(username);
            return this;
        }

       

        public LoginPagePOM SetPasssword(string password)
        {
            _passwordField.Clear();
            _passwordField.SendKeys(password);
            return this;
        }

        public void LoginForm()
        {
            _loginButton.Click();
        }

        
        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPasssword(password);
            LoginForm();
        }

        public bool LoginWithValidCredentials(string validUsername, string validPassword)
        {
            Login(validUsername, validPassword);
            bool success = true;
            Thread.Sleep(1000);
            try
            {
                _driver.SwitchTo().Alert();
                success = false;
            }
            catch (NoAlertPresentException ex)
            {
                
                success = true;
            }
            return success;
        }

        public bool AttemptLoginWithInvalidDetails(string InvalidUsername, string InvalidPassword)
        {
            Login(InvalidUsername, InvalidPassword);
            bool success = true;
            Thread.Sleep(1000);
            try
            {
                _driver.SwitchTo().Alert();
                success = false;
            }
            catch (NoAlertPresentException ex)
            {
                
                success = true;
            }
            return success;
        }
    }
}
