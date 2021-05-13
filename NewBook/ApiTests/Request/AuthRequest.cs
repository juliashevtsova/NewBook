using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NewBook.ApiTests
{
    public class AuthRequest
    {
        public  void ChangeEmail()
        {
            var user = CreateUserViaApi();            
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = driver;

            driver.Navigate().GoToUrl("https://newbookmodels.com/api/v1/auth/client/signup/");

            js.ExecuteScript($"localStorage.setItem('access_token','{user.token_data.token}');");

            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }

        public Root CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                 { "first_name", "Jsh" },
                 { "last_name", "Jsh" },
                 { "password", "28091999juliaA!" },
                 { "phone_number", "3453453454" }
             };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<Root>(response.Content);

            return createdUser;
        }        
    }
 }

