using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Basketball.Data.Repositories;
using Basketball.Scrape.Service;

namespace Basketball.Web.Controllers.MVC
{
    public class PlayerController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public PlayerController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPlayerInfo(string url)
        {
            PlayerInfo info = new PlayerInfo();
            var urlList = info.GetPlayerUrls(url, "China");
            return View(@"\Views\Player\Index.cshtml");
        }

        [HttpGet]
        public ActionResult Add()
        {
            var countries = _countryRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(string firstName)
        {
            return View();
        }
    }
}