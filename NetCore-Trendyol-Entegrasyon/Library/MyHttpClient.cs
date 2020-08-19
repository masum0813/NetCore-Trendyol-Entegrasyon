using System;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NetCore_Trendyol_Entegrasyon.Library
{
    public class MyHttpClient
    {

        public async Task<string> GetResponse(string rootUrl, string applicationUrl)
        {
            var retVal = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(rootUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                var response = await client.GetAsync(applicationUrl);

                if (response.IsSuccessStatusCode)
                {
                    retVal = await response.Content.ReadAsStringAsync();

                }
            }

            return retVal;


        }

    }
}
