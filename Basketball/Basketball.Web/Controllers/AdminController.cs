using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Basketball.Data.Repositories;
using Basketball.Models.Models;
using Basketball.Service;
using Basketball.Service.Scraping;
using Basketball.Web.ViewModels;

namespace Basketball.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ITeamService _teamService;
        private readonly IScrapingService _scrapingService;

        public AdminController(ICountryService countryService, ITeamService teamService, IScrapingService scrapingService)
        {
            this._countryService = countryService;
            this._teamService = teamService;
            this._scrapingService = scrapingService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCountry()
        {
            var countries = _countryService.GetCountries();
            var viewModelCountries = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(countries);
            return View(viewModelCountries);
        }

        [HttpPost]
        public ActionResult AddCountry(CountryViewModel viewmodel)
        {
            if (viewmodel != null)
            {
                var country = Mapper.Map<CountryViewModel, Country>(viewmodel);
                _countryService.CreateCountry(country);
                _countryService.SaveCountry();
            }
            return RedirectToAction("AddCountry"); ;
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            var countries = _countryService.GetCountries();
            var viewModelCountries = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(countries);
            var teams = _teamService.GetTeams();
            var viewModelTeams = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(teams);
            TeamCountryViewModel teamCountry = new TeamCountryViewModel
            {
                Countries = viewModelCountries,
                Teams = viewModelTeams
            };
            return View(teamCountry);
        }

        [HttpPost]
        public ActionResult AddTeam(TeamViewModel viewmodel)
        {
            if (viewmodel != null)
            {
                var team = Mapper.Map<TeamViewModel, Team>(viewmodel);
                _teamService.CreateTeam(team);
                _teamService.SaveTeam();
            }
            return RedirectToAction("AddTeam"); ;
        }

        [HttpGet]
        public ActionResult AddGames()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGames(string url)
        {
            if (url != null)
            {
                _scrapingService.GetGameStats(url);
            }
            return RedirectToAction("AddGames"); ;
        }
    }
}