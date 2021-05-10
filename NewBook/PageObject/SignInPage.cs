using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _emailField = By.CssSelector("[name = email]");
        private static readonly By _passwordField = By.CssSelector("[name = password]");
        private static readonly By _logInButton = By.CssSelector("[type = submit]");
        
        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage OpenSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage InputEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }
        public SignInPage InputPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }
        public void ClickLogInButton()
        {
            _webDriver.FindElement(_logInButton).Click();
        }

    }
}
