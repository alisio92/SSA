using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zoekertjes.WebApp.Models;

namespace Labo1_oef1._1Versie2
{
    public class WebServerAccess
    {
        private const string URL = "http://localhost:52065/api/ZoekertjeJson";

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

        public async Task<List<Categorie>> LoadCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Categorie> result = JsonConvert.DeserializeObject<List<Categorie>>(content);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Locatie>> LoadLocaties()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Locatie> result = JsonConvert.DeserializeObject<List<Locatie>>(content);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> addZoekertje(Zoekertje newZoekertje)
        {
            using (HttpClient client = new HttpClient())
            {
                //string URL = "http://localhost:64041/api";
                //string url = string.Format("{0}{1}", URL, "/zoekertjemobile");
                string json = JsonConvert.SerializeObject(newZoekertje);
                HttpResponseMessage response = await client.PostAsync(new Uri(URL), new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
