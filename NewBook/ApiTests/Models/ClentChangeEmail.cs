using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook.ApiTests
{
    public class ClentChangeEmail
    {
        public string Email { get; set; }
        
    }

    public class ClientChangePhoneNumber
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public class ClientChangePassword
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
