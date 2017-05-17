using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Basketball.Data.Infrastructure;
using Basketball.Data.Repositories;
using Basketball.Models;
using Basketball.Models.Models;
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
        private readonly IGameRepository gameRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScrapingService(ICountryRepository coungameRepositorytryRepository, IUnitOfWork unitOfWork)
        {
            this.gameRepository = gameRepository;
            this.unitOfWork = unitOfWork;
        }

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
            IList<JToken> firstTeamData = resultJson["tm"]["1"].Children().ToList();
            IList<JToken> firstTeam = resultJson["tm"]["1"]["pl"].Children().ToList();
            IList<JToken> secondTeamData = resultJson["tm"]["2"].Children().ToList();
            IList<JToken> secondTeam = resultJson["tm"]["2"]["pl"].Children().ToList();
            List<Performance> firstTeamPerformance = GetPerformanceFromJson(firstTeam);
            List<Performance> secondTeamPerformance = GetPerformanceFromJson(secondTeam);
            Game game = GetGameData(firstTeamData, secondTeamData);
            game.Performances = AddPerformances(firstTeamPerformance, secondTeamPerformance);
            gameRepository.Add(game);
        }

        private ICollection<Performance> AddPerformances(List<Performance> firstTeamPerformance, List<Performance> secondTeamPerformance)
        {
            ICollection<Performance> performances = new List<Performance>();
            foreach (var perf in firstTeamPerformance)
            {
                performances.Add(perf);
            }
            return performances;
        }

        private Game GetGameData(IList<JToken> firstTeamData, IList<JToken> secondTeamData)
        {
            var firstTeam = firstTeamData.First().ToObject<GameData>();
            var secondTeam = firstTeamData.First().ToObject<GameData>();
            Game game = new Game();
            game.HomeTeamId = 1;
            game.HTeam_1Q = firstTeam.p1_score;
            game.HTeam_2Q = firstTeam.p2_score;
            game.HTeam_3Q = firstTeam.p3_score;
            game.HTeam_4Q = firstTeam.p4_score;
            game.AwayTeamId = 2;
            game.ATeam_1Q = secondTeam.p1_score;
            game.ATeam_2Q = secondTeam.p2_score;
            game.ATeam_3Q = secondTeam.p3_score;
            game.ATeam_4Q = secondTeam.p4_score;
            return game;
        }

        private List<Performance> GetPerformanceFromJson(IList<JToken> team)
        {
            List<Performance> teamPerformance = new List<Performance>();
            foreach (JToken player in team)
            {
                var stats = player.First().ToObject<FIBAPlayerStats>();
                teamPerformance.Add(MapJsonToPerformance(stats));
            }
            return teamPerformance;
        }

        private Performance MapJsonToPerformance(FIBAPlayerStats stats)
        {
            Performance perf = new Performance();

            if (stats != null)
            {
                perf.As = stats.sAssists;
                perf.Bl = stats.sBlocks;
                perf.Dreb = stats.sReboundsDefensive;
                perf.Fo = stats.sFoulsPersonal;
                perf.Foa = stats.sFoulsOn;
                perf.Fta = stats.sFreeThrowsAttempted;
                perf.Ftm = stats.sFreeThrowsMade;
                perf.Oreb = stats.sReboundsOffensive;
                perf.PlayerId = 1;
                perf.PlusMinus = stats.sPlusMinusPoints;
                perf.St = stats.sSteals;
                perf.Starter = ConvertStarter(stats.starter);
                perf.ThreePtfga = stats.sThreePointersAttempted;
                perf.ThreePtfgm = stats.sThreePointersMade;
                perf.To = stats.sTurnovers;
                perf.TwoPtfga = stats.sTwoPointersAttempted;
                perf.TwoPtfgm = stats.sTwoPointersMade;
            }
            
            return perf;
        }

        private bool ConvertStarter(int statsStarter)
        {
            if (statsStarter == 1)
                return true;
            else return false;
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
