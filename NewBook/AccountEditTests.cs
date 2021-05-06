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
    public class AccountEditTests
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
        public void ChangePrimaryAccountHolderName()
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

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");

            var editButton = _webDriver.FindElements(By.CssSelector("[class=edit-switcher__icon_type_edit]"))[0];
            editButton.Click();

            var name = _webDriver.FindElements(By.CssSelector("input[class*=nput__self_type_text-underline]"))[0];
            name.Clear();
            name.SendKeys("Chris");

            var lastName =_webDriver.FindElements(By.CssSelector("input[class*=nput__self_type_text-underline]"))[1];
            lastName.Clear();
            lastName.SendKeys("Evans");

            var saveChange = _webDriver.FindElements(By.CssSelector("button[class*=button_type_default]"))[0];
            saveChange.Click();

            var result = _webDriver.FindElements(By.CssSelector("[class=paragraph_type_gray]"))[1].Text.Trim();

            Assert.AreEqual("Chris Evans", result);
        }
        [Test]
        public void ChangeCompanyLocation()
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

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");

            var editButton = _webDriver.FindElements(By.CssSelector("[class = edit-switcher__icon_type_edit]"))[0];
            editButton.Click();

            var companyLocation = _webDriver.FindElements(By.CssSelector("input[class*=nput__self_type_text-underline]"))[2];
            companyLocation.Clear();
            companyLocation.SendKeys("n");
            _webDriver.FindElement(By.CssSelector("[class = 'pac-item-query']")).Click();

            var saveChange = _webDriver.FindElements(By.CssSelector("button[class* = button_type_default]"))[0];
            saveChange.Click();

            var result = _webDriver.FindElements(By.CssSelector("[class = paragraph_type_gray]"))[1].Text.Trim();

            Assert.AreEqual("New York, NY, USA", result);
        }        
    }
}
