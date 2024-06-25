using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BackFacture.app
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ConsumeAPIAsync(JObject request)
        {
            try
            {
                if (!CheckInternetConnection())
                {
                    Console.WriteLine("Error: No hay conexión a internet");
                    return "";
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "YOUR_ACCESS_TOKEN");

                var response = await _httpClient.GetAsync("https://api.example.com/data");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(json);

                    Console.WriteLine($"Nombre: {data.Name}");
                    Console.WriteLine($"Edad: {data.Age}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }

            }
            catch (HttpRequestException err)
            {
                Console.WriteLine(err.Message);
                throw;
            }
            return "";
        }

        static bool IsOnline()
        {
            try
            {
                var request = WebRequest.Create("http://google.com/generate_204") as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException)
            {
                return false;
            }
        }

        static bool CheckInternetConnection()
        {
            try
            {
                var webClient = new WebClient();
                return webClient.DownloadString("https://google.com/generate_204") != null;
            }
            catch (WebException)
            {
                return false;
            }
        }

        public async Task<HttpResponseMessage> SendGetRequestAsync(string url)
        {
            try
            {
                return await _httpClient.GetAsync(url);
            }
            catch (HttpRequestException err)
            {
                Console.WriteLine(err.Message);
                throw;
            }
        }

    }

}