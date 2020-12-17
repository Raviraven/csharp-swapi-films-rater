using Microsoft.AspNetCore.Mvc;
using swapi_films_rater.Models;
using swapi_films_rater.Models.DBModels;
using swapi_films_rater.Repository.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.Models.ViewModels;
using swapi_films_rater.Repository.DALServices;

namespace swapi_films_rater.Controllers
{
    public class FilmsController : Controller
    {
        private IFilmsSwapiService _filmsSwapiService { get; set; }
        //private IFilmRatingsDAL _filmRatingsDAL { get; set; }
        private readonly IFilmRatingsDalService _filmRatingsDalService;

        public FilmsController(IFilmsSwapiService filmsSwapiService, IFilmRatingsDalService filmRatingsDalService
            )
        {
            _filmsSwapiService = filmsSwapiService;
            //_filmRatingsDAL = filmRatingsDAL;
            _filmRatingsDalService = filmRatingsDalService;
        }

        public async Task<IActionResult> Details(int Id)
        {
            var filmDetails = await _filmsSwapiService.Get(Id);
            var filmRatings = await _filmRatingsDalService.GetByEpisodeId(filmDetails.Episode_id);

            var filmDetailsViewModel = new FilmDetailsViewModel()
            {
                UrlId = Id,
                ApiDetails = filmDetails,
                FilmRatings = filmRatings
            };

            return View(filmDetailsViewModel);
        }

        public IActionResult Rate(int urlId, int episodeId, string title)
        {
            var model = new FilmRateViewModel { UrlId = urlId, EpisodeId = episodeId, MovieName = title };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Rate(FilmRateViewModel filmRate)
        {
            if (ModelState.IsValid)
            {
                await _filmRatingsDalService.Add(filmRate); //_filmRatingsDAL.Add(filmRate);
                return RedirectToAction("Details", new { Id = filmRate.UrlId });
            }
            else
            {
                return View(filmRate);
            }
        }
    }
}
