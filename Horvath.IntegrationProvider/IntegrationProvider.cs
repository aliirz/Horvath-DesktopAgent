using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using Horvath.Client;

namespace Horvath
{
    public class IntegrationProvider
    {
        private RestClient _client;
        private string _passcode;

        /// <summary>
        /// pass in the url of the server here.
        /// </summary>
        /// <param name="url"></param>
        public IntegrationProvider(string url, string passcode)
        {
            this._client = new RestClient(url);
            this._passcode = passcode;
            //this._client.AddHandler("application/json", new DynamicJsonDeserializer());

        }

        /// <summary>
        /// Get the latest command from Merlin.
        /// </summary>
        /// <returns></returns>
        public Command GetCommand()
        {
            Command command = new Command();
            try
            {
                var request = new RestRequest("query", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new { txtQuery = _passcode });

                var response = this._client.Execute<Command>(request);  //lets deserialize it as we get it.

                if (response.Content == "\"Waiting!\"")
                {
                    return command;
                }

                command.id = response.Data.id;
                command.command_text = response.Data.command_text;
                command.file = response.Data.file;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return command;
        }


        public void SendConfirmation(int id, bool status)
        {
            try
            {
                var request = new RestRequest("done", Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddBody(new { done = status, txtQuery = id });
                this._client.Execute(request);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public bool CheckConnectivity()
        {
            bool connected = true;
            try
            {

                var request = new RestRequest("query", Method.POST);
                request.RequestFormat = DataFormat.Json;
                //request.RequestBody

                request.AddBody(new { txtQuery = "3f14110ba" });
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
