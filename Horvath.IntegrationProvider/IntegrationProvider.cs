using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace Horvath
{
    public class IntegrationProvider
    {
        private RestClient _client;

        public IntegrationProvider(string url)
        {
            this._client = new RestClient(url);
            this._client.Authenticator = new HttpBasicAuthenticator("yawar", "shah");
        }

        public bool CheckConnectivity()
        {
            bool connected = true;
            try
            {   
        
                var request = new RestRequest("authenticate", Method.POST);
                request.Parameters.Add(new Parameter { Name = "username", Value = "yawar" });
                request.Parameters.Add(new Parameter { Name = "password", Value = "shah" });
                

                var response = this._client.Execute(request);

                Console.WriteLine(response.Content);
                connected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connected = false;
            }

            return connected;
        }
    }
}
