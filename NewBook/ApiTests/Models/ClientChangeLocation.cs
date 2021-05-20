using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook.ApiTests
{
    public class ClientChangelocation
        {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("facebook_followers")]
        public object facebook_followers { get; set; }
        [JsonProperty("instagram_followers")]
        public object instagram_followers { get; set; }
        [JsonProperty("invite")]
        public bool has_invite { get; set; }
        [JsonProperty("company_website")]
        public object company_website { get; set; }
        [JsonProperty("company_name")]
        public object company_name { get; set; }
        [JsonProperty("company_description")]
        public object company_description { get; set; }
        [JsonProperty("referral")]
        public object referral { get; set; }
        [JsonProperty("phone_number")]
        public string phone_number { get; set; }
        [JsonProperty("is_sms_enabled")]
        public bool is_sms_enabled { get; set; }
        [JsonProperty("location_latitude")]
        public double location_latitude { get; set; }
        [JsonProperty("Location_longitude")]
        public double location_longitude { get; set; }
        [JsonProperty("location_name")]
        public string Location_name { get; set; }
        [JsonProperty("location_city_name")]
        public string location_city_name { get; set; }
        [JsonProperty("location_admin1_code")]
        public string location_admin1_code { get; set; }
        [JsonProperty("location_timezone")]
        public string location_timezone { get; set; }
        [JsonProperty("company_address")]
        public string company_address { get; set; }
        [JsonProperty("industry")]
        public string industry { get; set; }
        [JsonProperty("twitter_followers")]
        public object twitter_followers { get; set; }
        [JsonProperty("youtube_followers")]
        public object youtube_followers { get; set; }
        }
    
}
