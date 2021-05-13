using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook.ApiTests
{
    public class ApiTest
    {
        public void Tests()
        {
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                 { "first_name", "Jsh" },
                 { "last_name", "Jsh" },
                 { "password", "28091999juliaA!" },
                 { "phone_number", "3453453454" }
             };

            var createdUser = ; 
        }

    }
}
