using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook.ApiTests
{
    public class ApiTest
    {
        [Test]
        public void CheckChangeEmail()
        {
            var expectedEmail = $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com";
            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualEmail = ClientRequests.SendRequestChangeClientEmailPost("julia28091999A!", expectedEmail, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void CheckChangePassword()
        {
            var expectedResult = "shevtsova28091999A!";
            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualResult = ClientRequests.SendRequestChangeClientPasswordPost("julia28091999A!", expectedResult, crearedUser.TokenData.Token);

            Assert.AreEqual(crearedUser.TokenData.Token, actualResult);
        }

        [Test]
        public void CheckChangePhoneNumber()
        {
            var expectedResult = "0987654321";
            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualResult = ClientRequests.SendRequestChangePhoneNumberPost("julia28091999A!", expectedResult, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckChangeGeneralInfoFirstName()
        {
            var expectedResult = "Chris";
            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualResult = ClientRequests.SendRequestChangeGeneralInformationFirstNamePatch(expectedResult, crearedUser.User.LastName, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckChangeGeneralInfoLastName()
        {
            var expectedResult = "Evans";
            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualResult = ClientRequests.SendRequestChangeGeneralInformationLastNamePatch(expectedResult, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckChangeGeneralInformationLocation()
        {
            var expectedResult = "1208 Hall St, Dallas, TX 75204, USA";

            var user = new Dictionary<string, string>
            {
                { "email", $"julia{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Julz" },
                { "last_name", "Sheva" },
                { "password", "julia28091999A!" },
                { "phone_number", "1234567890" }
            };

            var crearedUser = AuthRequest.SendRequestClientSingUpPost(user);

            var actualResult = ClientRequests.SendRequestChangeGeneralInfoLocationPatch(expectedResult, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
