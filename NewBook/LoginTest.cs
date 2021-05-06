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
    public class LoginTest
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

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = email]")).SendKeys("iulishev1@gmail.com");
            _webDriver.FindElement(By.CssSelector("[name = password]")).SendKeys("julia28091999A!");

            _webDriver.FindElement(By.CssSelector("[type = submit]")).Click();

            wait.Until(ExpectedConditions.UrlContains("explore"));

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", result);

        }
    }
}
