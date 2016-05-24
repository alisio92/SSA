using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zoekertjes.WebApp.Models;

namespace labo4_oef1._1
{
    public class WebserverAccess
    {
        private const string URL = "http://localhost:1117/api/ZoekertjeJson";

        public async Task<List<Zoekertje>> LoadZoekertjes()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Zoekertje> result = JsonConvert.DeserializeObject<List<Zoekertje>>(content);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
