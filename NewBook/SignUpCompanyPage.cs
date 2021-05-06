using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook
{
    public class SignUpCompanyPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _companyNameField = By.CssSelector("[name = company_name]");
        private static readonly By _companyWebsiteField = By.CssSelector("[name = company_website]");
        private static readonly By _addressField = By.CssSelector("[name = location]");
        private static readonly By _addressListField = By.CssSelector("[class^='pac-matched']");
        private static readonly By _insdustryField = By.CssSelector("[name = industry]");
        private static readonly By _insdustryListField = By.CssSelector("[role='option']");
        private static readonly By _nextButton = By.CssSelector("[type = submit]");

        //var companyName = _webDriver.FindElement(By.CssSelector("[name = 'company_name']"));
        //companyName.SendKeys("Julia");
        //    var companyWebsite = _webDriver.FindElement(By.CssSelector("[name = 'company_website']"));
        //companyWebsite.SendKeys("julia.com");
        //    var address = _webDriver.FindElement(By.CssSelector("[name = 'location']"));
        //address.SendKeys("1");

        //    System.Threading.Thread.Sleep(2000);
        //    _webDriver.FindElements(By.CssSelector("[class^='pac-matched']"))[0].Click();


        //_webDriver.FindElement(By.CssSelector("[name='industry']")).Click();
        //_webDriver.FindElements(By.CssSelector("[role='option']"))[0].Click();
        //System.Threading.Thread.Sleep(4000);
        //    _webDriver.FindElement(By.CssSelector("[type = submit]")).Click();
        public SignUpCompanyPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpCompanyPage OpenSignUpCompanyPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join/company/");
            return this;
        }

        public SignUpCompanyPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }

        public SignUpCompanyPage SetCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public SignUpCompanyPage SetAdress(string adress)
        {
            _webDriver.FindElement(_addressField).SendKeys(adress);
            _webDriver.FindElement(_addressListField).Click();
            return this;
        }

        public SignUpCompanyPage SetIndustry(string industry)
        {
            _webDriver.FindElement(_insdustryField).Click();
            _webDriver.FindElement(_insdustryListField).Click();
            return this;
        }

        public void ClickRegistrationButton()
        {
            _webDriver.FindElement(_nextButton).Click();
        }

        public void Registration()
        {
            SignUpPage firstData = new SignUpPage(_webDriver);
            firstData.OpenSignUpPage();
            firstData.SetName("Julz");
            firstData.SetLastName("Shevts");
            firstData.SetEmail("iu9873@gmail.com");
            firstData.SetPassword("12345678Qq!");
            firstData.SetPasswordConfirm("12345678Qq!");
            firstData.SetNumber("1234567890");
            firstData.ClickRegistrationButton();
        }
    }
}
