using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook.ApiTests
{
        public class ClientProfile
        {
            public string id { get; set; }
            public object facebook_followers { get; set; }
            public object instagram_followers { get; set; }
            public bool has_invite { get; set; }
            public object company_website { get; set; }
            public object company_name { get; set; }
            public object company_description { get; set; }
            public object referral { get; set; }
            public string phone_number { get; set; }
            public bool is_sms_enabled { get; set; }
            public object location_latitude { get; set; }
            public object location_longitude { get; set; }
            public object location_name { get; set; }
            public object location_city_name { get; set; }
            public object location_admin1_code { get; set; }
            public object location_timezone { get; set; }
            public object company_address { get; set; }
            public object industry { get; set; }
            public object twitter_followers { get; set; }
            public object youtube_followers { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public bool payment_method_connected { get; set; }
            public bool is_staff { get; set; }
            public bool email_verified { get; set; }
            public ClientProfile client_profile { get; set; }
            public bool has_password { get; set; }
            public object avatar { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
        }

        public class TokenData
        {
            public string token { get; set; }
            public DateTime token_refresh_expires { get; set; }
            public string firebase_token { get; set; }
            public DateTime firebase_token_expires { get; set; }
        }

        public class Root
        {
            public User user { get; set; }
            public TokenData token_data { get; set; }
        }    
}
