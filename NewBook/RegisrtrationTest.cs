using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;


namespace NewBook
{
    public class RegistrationTests
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
        public void InputValidData()
        {
            Random random = new Random();
            var e_mail = random.Next(10, 99);

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");

            var name = _webDriver.FindElement(By.CssSelector("[name = first_name]"));
            name.SendKeys("Julia");
            var lastName = _webDriver.FindElement(By.CssSelector("[name = last_name]"));
            lastName.SendKeys("Shevtsova");
            var email = _webDriver.FindElement(By.CssSelector("[name = 'email']"));
            email.SendKeys($"ahjkj{e_mail}uho@gmail.com");
            var password = _webDriver.FindElement(By.CssSelector("[name = 'password']"));
            password.SendKeys("julia28091999A!");
            var repeatPassword = _webDriver.FindElement(By.CssSelector("[name = 'password_confirm']"));
            repeatPassword.SendKeys("julia28091999A!");
            var number = _webDriver.FindElement(By.CssSelector("[name= 'phone_number']"));
            number.SendKeys("3456786542");
            _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();

            wait.Until(ExpectedConditions.UrlContains("company"));

            var companyName = _webDriver.FindElement(By.CssSelector("[name = 'company_name']"));
            companyName.SendKeys("Julia");
            var companyWebsite = _webDriver.FindElement(By.CssSelector("[name = 'company_website']"));
            companyWebsite.SendKeys("julia.com");
            var address = _webDriver.FindElement(By.CssSelector("[name = 'location']"));
            address.SendKeys("1");

            wait.Until(ExpectedConditions.ElementExists(By.Name("location")));

            _webDriver.FindElements(By.CssSelector("[class^='pac-matched']"))[0].Click();
            _webDriver.FindElement(By.CssSelector("[name='industry']")).Click();
            _webDriver.FindElements(By.CssSelector("[role='option']"))[0].Click();

            _webDriver.FindElement(By.CssSelector("button[class^=SignupCompanyForm__submitButton]")).Click();

            wait.Until(ExpectedConditions.UrlContains("explore"));

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", result);
        }
    }
}
