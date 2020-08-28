using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GuiClient.Http
{
    public class APIClient
    {
        HttpClient apiEndpoint;
        string endpoint;

        public APIClient(string endPointUri)
        {
            apiEndpoint = new HttpClient();
            endpoint = endPointUri;
        }

        public async Task<string> SendRequest(APIModel reqModel)
        {
            try
            {
                var requestJSON = JsonConvert.SerializeObject(reqModel);
                /*
                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Content = new StringContent(requestJSON, Encoding.Unicode, "application/json");

                var response = await apiEndpoint.SendAsync(request);
                */
                var response = await apiEndpoint.PostAsync(endpoint, new StringContent(requestJSON, Encoding.UTF8, "application/json"));
                return string.Format("Status = {0} - {1}", response.StatusCode, response.Content);
            }
            catch (Exception e)
            {
                var exc = e.ToString();
                return null;
            }
        }
    }
}
