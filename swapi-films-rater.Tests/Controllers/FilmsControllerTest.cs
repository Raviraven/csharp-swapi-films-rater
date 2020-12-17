using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using swapi_films_rater.Repository.APIServices;
using swapi_films_rater.Repository.DALServices;
using swapi_films_rater.Models.ViewModels;
using swapi_films_rater.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace swapi_films_rater.Tests.Controllers
{
    public class FilmsControllerTest
    {
        [Fact]
        public async Task RatePost_ReceivesInvalidModelState_ReturnsPassedViewModel()
        {
            var filmsSwapiService = new Mock<IFilmsSwapiService>();
            var filmRatingsDalService = new Mock<IFilmRatingsDalService>();

            var viewModel = new FilmRateViewModel() { 
                Username = "Test username",
                Rate = -1,
                EpisodeId = 90,
                Title = "Test title",
                UrlId = -9
            };

            var filmsController = new FilmsController(filmsSwapiService.Object, filmRatingsDalService.Object);

            filmsController.ModelState.AddModelError("", "");
            var result = await filmsController.Rate(viewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<FilmRateViewModel>(viewResult.ViewData.Model);
            Assert.Equal(viewModel, model);
        }
    }
}
