using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Net;

namespace Tutor_Database.RestApiHelper
{
    [JsonObject]
    public class RestApiAllData
    {
        private CityFromRest city = new CityFromRest();
        private ProfessionFromRest profession = new ProfessionFromRest();
        private List<CityFromRest> citiesFromRest = new List<CityFromRest>();
        private List<ProfessionFromRest> professionsFromRest = new List<ProfessionFromRest>();
        private readonly string citiesUrl = "https://raw.githubusercontent.com/royts/israel-cities/master/israel-cities.json";
        private readonly string professionsUrl = "https://raw.githubusercontent.com/guardian/university-guide-2016/master/data/guardianSubjectGroups.json";

        public List<string> GetCities()
        {
            List<string> citiesToReturn = new List<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(citiesUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                using (var webClinet = new WebClient())
                {
                    string jsons = webClinet.DownloadString(citiesUrl);
                    citiesFromRest = JsonConvert.DeserializeObject<List<CityFromRest>>(jsons);
                }
                citiesFromRest.RemoveAt(0);
                foreach (var item in citiesFromRest)
                {
                    citiesToReturn.Add(item.english_name);
                }
                citiesToReturn.Sort();
                citiesToReturn.RemoveAll((s) => { return s == ""; });
            }
            return citiesToReturn;
        }
        public List<string> GetProfessions()
        {
            List<string> professionsToReturn = new List<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(professionsUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                using (var webClinet = new WebClient())
                {
                    string jsons = webClinet.DownloadString(professionsUrl);
                    professionsFromRest = JsonConvert.DeserializeObject<List<ProfessionFromRest>>(jsons);
                }
                //professionsFromRest.RemoveAt(0);
                foreach (var item in professionsFromRest)
                {
                    professionsToReturn.Add(item.guardianSubjectGroup);
                }
                professionsToReturn.Sort();
                professionsToReturn.RemoveAll((s) => { return s == ""; });
            }
            return professionsToReturn;
        }
    }
}
