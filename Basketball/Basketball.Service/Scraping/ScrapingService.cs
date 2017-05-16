using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Basketball.Models;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Basketball.Service.Scraping
{
    public interface IScrapingService
    {
        Task GetGameStats(string url);
    }

    public class ScrapingService : IScrapingService
    {
        private HttpClient client;

        public async Task GetGameStats(string url)
        {
            Uri uri = new Uri(url);
            var host = uri.Host;
            switch (host)
            {
                case "www.fibalivestats.com":
                    await GetFromFIBA(url);
                    break;
                default:
                    break;

            }
        }

        public async Task GetFromFIBA(string url)
        {
            string result = "";
            client = new HttpClient();
            string gameId = GetGameIdFromUrl(url);

            var dataUrl = new Uri("http://www.fibalivestats.com/data/" + gameId + "/data.json");
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(dataUrl).ConfigureAwait(false))
            using (HttpContent content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }

            JObject resultJson = JObject.Parse(result);
            IList<JToken> firstTeam = resultJson["tm"]["1"]["pl"].Children().ToList();
            IList<JToken> secondTeam = resultJson["tm"]["2"]["pl"].Children().ToList();
            foreach (JToken player in firstTeam)
            {
                var stats = player.First().ToObject<FIBAPlayerStats>();
                var fibaplayerstat = stats;
            }
        }
        


        private string GetGameIdFromUrl(string url)
        {
            var splitUrl = url.Split('/');
            foreach (var part in splitUrl)
            {
                if (IsDigitsOnly(part))
                    return part;
            }
            return null;
        }

        static bool IsDigitsOnly(string str)
        {
            if (str.Length > 3)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
