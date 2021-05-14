using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace NewBook.ApiTests
{
    public static class ClientRequests
    {
        public static string SendRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                    {"password", password},
                    {"email", email},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var clientChangeEmail = JsonConvert.DeserializeObject<ClentChangeEmail>(response.Content);

            return clientChangeEmail.Email;
        }

        public static string SendRequestChangeClientPasswordPost(string password, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", password},
                { "new_password", newPassword},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangePasswordResponse = JsonConvert.DeserializeObject<ClientChangePassword>(response.Content);

            return ChangePasswordResponse.Token;
        }

        public static string SendRequestChangePhoneNumberPost(string password, string phone_number, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newNumberPhone = new Dictionary<string, string>
            {
                    {"password", password},
                    {"phone_number", phone_number},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newNumberPhone);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var clientChangePhoneNumber = JsonConvert.DeserializeObject<CLientChangePhoneNumber>(response.Content);

            return clientChangePhoneNumber.phone_number;
        }

        public static string SendRequestChangeGeneralInformationFirstNamePost(string first_name,string last_name, string token)
        {

            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newName = new Dictionary<string, string>
            {
                    {"first_name", first_name},
                    {"last_name", last_name},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newName);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var clientChangeName = JsonConvert.DeserializeObject<ClientChangeName>(response.Content);

            return clientChangeName.FirstName;
        }

        public static string SendRequestChangeGeneralInformationLastNamePost(string last_name, string token)
        {

            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newLastName = new Dictionary<string, string>
            {
                    {"last_name", last_name},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newLastName);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var clientChangeName = JsonConvert.DeserializeObject<ClientChangeName>(response.Content);

            return clientChangeName.LastName;
        }
    }
 }

