using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System;


namespace worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting user profiles...");
            GetUserProfiles();
        }

        public static async Task GetUserProfiles()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var result = await client.GetAsync("https://localhost:5001/api/profiles");
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine("profiles api returned: " + resultContent);
                }
            }
        }
    }
}
