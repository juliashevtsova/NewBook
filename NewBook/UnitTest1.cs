using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20000);
        }

        [Test]
        public void InputValidFirstData()
        {
            var signUpPage = new SignUpPage(_webDriver);
            signUpPage.OpenSignUpPage()
                .SetName("Julia")
                .SetLastName("Shevtsova")
                .SetEmail("julia78shevtsov6@gmail.com")
                .SetPassword("12345678qQ!")
                .SetPasswordConfirm("12345678qQ!")
                .SetNumber("1234567890")
                .ClickRegistrationButton();

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", result);
        }

        [Test]
        public void InputCompanyData()
        {            
            var signUpCompanyPage = new SignUpCompanyPage(_webDriver);
            signUpCompanyPage.Registration();
            signUpCompanyPage
                .SetCompanyName("Julia")
                .SetCompanyWebsite("Shevtsova.com")
                .SetAdress("1155 East Oakton Street, Des Plaines, IL, USA")
                .SetIndustry("CPG");               

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", result);
        }
    }
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
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = email]")).SendKeys("shevi@gmail.com");
            _webDriver.FindElement(By.CssSelector("[name = password]")).SendKeys("rfrfirf28091999juliaA!");
            
            _webDriver.FindElement(By.CssSelector("[type = submit]")).Click();

            System.Threading.Thread.Sleep(2000);

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", result);

        }
    }
    public class ProfileChange
    {

    }
}