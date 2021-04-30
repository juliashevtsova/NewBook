using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;


namespace NewBookModels
{
    public class Registration
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
        public void InputValidDate()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");


            var name = _webDriver.FindElement(By.CssSelector("[name = first_name]"));
            name.SendKeys("Julia");
            var lastName = _webDriver.FindElement(By.CssSelector("[name = last_name]"));
            lastName.SendKeys("Shevtsova");
            var email = _webDriver.FindElement(By.CssSelector("[name = 'email']"));
            email.SendKeys("assssaio@gmail.com");
            var password = _webDriver.FindElement(By.CssSelector("[name = 'password']"));
            password.SendKeys("julia28091999A!");
            var repeatPassword = _webDriver.FindElement(By.CssSelector("[name = 'password_confirm']"));
            repeatPassword.SendKeys("julia28091999A!");
            var number = _webDriver.FindElement(By.CssSelector("[name= 'phone_number']"));
            number.SendKeys("3456786542");
            _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();

            System.Threading.Thread.Sleep(4000);

            var companyName = _webDriver.FindElement(By.CssSelector("[name = 'company_name']"));
            companyName.SendKeys("Julia");
            var companyWebsite = _webDriver.FindElement(By.CssSelector("[name = 'company_website']"));
            companyWebsite.SendKeys("julia.com");
            var address = _webDriver.FindElement(By.CssSelector("[name = 'location']"));
            address.SendKeys("1");
           
            System.Threading.Thread.Sleep(2000);
            _webDriver.FindElements(By.CssSelector("[class^='pac-matched']"))[0].Click();


            _webDriver.FindElement(By.CssSelector("[name='industry']")).Click();
            _webDriver.FindElements(By.CssSelector("[role='option']"))[0].Click();
            System.Threading.Thread.Sleep(4000);
            _webDriver.FindElement(By.CssSelector("[type = submit]")).Click();

            System.Threading.Thread.Sleep(10000);

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", result);

        }
    }
    public class Login
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
}