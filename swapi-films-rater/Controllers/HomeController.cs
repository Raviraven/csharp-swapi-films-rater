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
        private FilmsHelper _filmsService { get; set; }

        public HomeController(IFilmsSwapiService filmsSwapiService,
            FilmsHelper filmsService)
        {
            _filmsSwapiService = filmsSwapiService;
            _filmsService = filmsService;
        }

        public async Task<IActionResult> Index()
        {
            var filmsContainer = await _filmsSwapiService.Get();
            var filmsList = _filmsService.GetTitlesAndEpisodes(filmsContainer.Results);
            filmsList = filmsList.OrderBy(n => n.EpisodeId).ToList();

            return View(filmsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
