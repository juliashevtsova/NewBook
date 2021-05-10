using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook
{
    class AccountSettingsPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _generalInfoButton = By.CssSelector("[nb-account-info-general-information .edit-switcher__icon_type_edit]");
        private static readonly By _emailAddressButton = By.CssSelector("[nb-account-info-email-address .edit-switcher__icon_type_edit]");
        private static readonly By _passwordButton = By.CssSelector("[nb-account-info-password .edit-switcher__icon_type_edit]");
        private static readonly By _phoneNumber = By.CssSelector("[nb-account-info-phone. edit-switcher__icon_type_edit]");
        private static readonly By _logOut = By.CssSelector("[type=logout]");
        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSettingsPage OpenSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public void ChangeGeneralInfo()
        {
            _webDriver.FindElement(_generalInfoButton).Click();
        }
        public void ChangeEmailAddress()
        {
            _webDriver.FindElement(_emailAddressButton).Click();
        }
        public void ChangePassword()
        {
            _webDriver.FindElement(_passwordButton).Click();
        }
        public void ChangePhoneNumber()
        {
            _webDriver.FindElement(_phoneNumber).Click();
        }
        public void ClickLogOut()
        {
            _webDriver.FindElement(_logOut).Click();
        }
        public void LogIn()
        {
            SignInPage logIn = new SignInPage(_webDriver);
            logIn.OpenSignInPage()
                .InputEmail("iulishev1@gmail.com")
                .InputPassword("julia28091999A!")
                .ClickLogInButton();
        }
    }
}