using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace DropboxApp
{
    public class WebServerAccess
    {
        private const string URL = "http://localhost:14319/api/LogJson";

        public TokenResponse GetToken(string userName, string password)
        {
            var client = new OAuth2Client(new Uri("http://localhost:14319/token"));
            return client.RequestResourceOwnerPasswordAsync(userName, password).Result;
        }
        
        public async Task<List<FileLog>> LoadLogs()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<FileLog> result = JsonConvert.DeserializeObject<List<FileLog>>(content);
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
