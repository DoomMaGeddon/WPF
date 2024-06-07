using System;
using System.Net.Http;

namespace admin
{
    internal class Api
    {
        public static HttpClient Client()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Constants.API_URL)
            };

            var token = Store.Instance.GetStateItem("Token");
            if (token != null)
            {
                client.DefaultRequestHeaders.Add("auth-token", token);
            }

            return client;
        }
    }
}
