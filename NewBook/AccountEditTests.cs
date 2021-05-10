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
            
            var accountSettingsPage = new AccountSettingsPage(_webDriver);

            accountSettingsPage.LogIn();
           //accountSettingsPage.ClickCloseWindowVerification();
            accountSettingsPage.ClickAvatarClient();
            accountSettingsPage.ClickGeneralInfoButton();
            accountSettingsPage.ChangeName("Chris")
                .ChangeLastName("Evans").
                ClickSaveButton();            

            var result = _webDriver.FindElements(By.CssSelector("[class=paragraph_type_gray]"))[1].Text.Trim();

            Assert.AreEqual("Chris Evans", result);
        }        
    }
}