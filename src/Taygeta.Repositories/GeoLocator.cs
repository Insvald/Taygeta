// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Net;
using Newtonsoft.Json;

namespace Taygeta.Repositories
{    
    public class GeoLocator : IGeoLocator
    {
        /// <inheritdoc />
        public bool GetLocationByIp(string ipAddress, out string country, out string city)
        {
            using (WebClient client = new WebClient())
            {
                dynamic resultObject = JsonConvert.DeserializeObject(client.DownloadString($"http://ip-api.com/json/{ipAddress}"));
                if (resultObject.status == "success")
                {
                    country = resultObject.country;
                    city = resultObject.city;
                    return true;
                }
                
                // something happened
                country = "";
                city = "";
                return false;
            }
        }
    }
}
