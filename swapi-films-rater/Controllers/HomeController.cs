using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using swapi_films_rater.Models;
using swapi_films_rater.Repository.APIServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.Repository.Helpers;

namespace swapi_films_rater.Controllers
{
    public class HomeController : Controller
    {
        private IFilmsSwapiService _filmsSwapiService { get; set; }
        private FilmsHelper FilmsService { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFilmsSwapiService filmsSwapiService,
            FilmsHelper filmsService)
        {
            _logger = logger;
            _filmsSwapiService = filmsSwapiService;
            FilmsService = filmsService;
        }

        public async Task<IActionResult> Index()
        {
            var filmsContainer = await _filmsSwapiService.Get();
            var dropDownList = FilmsService.GetTitlesAndEpisodes(filmsContainer.Results);

            return View(dropDownList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
