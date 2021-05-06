using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;


namespace NewBook
{
    public class LogOutTest
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
        public void LogOut()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            var email = _webDriver.FindElement(By.CssSelector("[name = email]"));
            email.SendKeys("iulishev1@gmail.com");

            var password = _webDriver.FindElement(By.CssSelector("[name = password]"));
            password.SendKeys("julia28091999A!");

            _webDriver.FindElement(By.CssSelector("[type = submit]")).Click();

            wait.Until(ExpectedConditions.UrlContains("explore"));

            _webDriver.FindElement(By.CssSelector("common-resend-email div[class = modal__close]")).Click();

            var avatarClient = _webDriver.FindElement(By.CssSelector("[class^=AvatarClient__avatar]"));
            avatarClient.Click();

            var logOut = _webDriver.FindElement(By.CssSelector("div[class*= link_type_logout]"));
            logOut.Click();

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/auth/signin", result);
        }
    }
}
