using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;


namespace NewBook
{
    public class LoginTests
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void InputValidLogin()
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.OpenSignInPage()
                .InputEmail("iulishev1@gmail.com")
                .InputPassword("julia28091999A!")
                .ClickLogInButton();

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", result);
        }
    }
}