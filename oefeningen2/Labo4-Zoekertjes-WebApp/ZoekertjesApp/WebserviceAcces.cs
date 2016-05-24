using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zoekertjes.Models;

namespace ZoekertjesApp
{
    public class WebserviceAcces
    {
        private const string URL = "http://localhost:2519/api";
        private const string Url = "http://localhost:2519/api/values/";

        private const string UrlCat = "http://localhost:2519/api/categorie/";
        private const string UrlLoc = "http://localhost:2519/api/locatie/";

        public List<Zoekertje> result;
        public List<Categorie> resultCat;
        public List<Locatie> resultLoc;

        public async Task<List<Zoekertje>> Load()
        {
            using (HttpClient client = new HttpClient())
            {
                //string url = string.Format("{0}{1}", URL, "/values");
                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Zoekertje>>(json);
                    return result;
                }
                return null;
            }
        }

        public async Task<List<Categorie>> LoadCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                //string url = string.Format("{0}{1}", URL, "/values");
                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    resultCat = JsonConvert.DeserializeObject<List<Categorie>>(json);
                    return resultCat;
                }
                return null;
            }
        }

        public async Task<List<Locatie>> LoadLocaties()
        {
            using (HttpClient client = new HttpClient())
            {
                //string url = string.Format("{0}{1}", URL, "/values");
                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    resultLoc = JsonConvert.DeserializeObject<List<Locatie>>(json);
                    return resultLoc;
                }
                return null;
            }
        }
    }
}
