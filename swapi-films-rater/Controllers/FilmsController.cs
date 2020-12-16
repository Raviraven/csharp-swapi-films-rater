using Microsoft.AspNetCore.Mvc;
using swapi_films_rater.Models;
using swapi_films_rater.Models.DBModels;
using swapi_films_rater.Repository.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.DB.DTO;

namespace swapi_films_rater.Controllers
{
    public class FilmsController : Controller
    {
        private IFilmsSwapiService _filmsSwapiService { get; set; }
        private IFilmRatingsDAL _filmRatingsDTO { get; set; }

        public FilmsController(IFilmsSwapiService filmsSwapiService, IFilmRatingsDAL filmRatingsDTO)
        {
            _filmsSwapiService = filmsSwapiService;
            _filmRatingsDTO = filmRatingsDTO;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var filmDetails = await _filmsSwapiService.Get(Id);

            var filmDetailsViewModel = new FilmDetailsViewModel()
            {
                ApiDetails = filmDetails
            };

            return View(filmDetailsViewModel);
        }

        [HttpPost]
        public async Task AddRating(FilmRating filmRating)
        {
            await _filmRatingsDTO.Add(filmRating);
        }
    }
}
