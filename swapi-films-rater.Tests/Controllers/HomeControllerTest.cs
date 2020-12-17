using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using swapi_films_rater.Repository.APIServices;
using swapi_films_rater.Repository.Helpers;
using swapi_films_rater.Models.APIModels;
using swapi_films_rater.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using swapi_films_rater.Controllers;
using System.Threading.Tasks;

namespace swapi_films_rater.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public async Task Index_ReceivesFilmsList_ReturnsViewResultFilledWithModel()
        {
            var filmsSwapiService = new Mock<IFilmsSwapiService>();
            var filmsHelper = new Mock<IFilmsHelper>();

            var filmListVM = new List<FilmListViewModel>()
            { 
                new FilmListViewModel(),
                new FilmListViewModel()
            };


            filmsSwapiService.Setup(n => n.Get()).ReturnsAsync(new FilmsContainer());
            filmsHelper.Setup(n => n.GetTitlesAndEpisodes(It.IsAny<Film[]>()))
                .Returns(filmListVM);

            var homeController = new HomeController(filmsSwapiService.Object, filmsHelper.Object);

            var result = await homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FilmListViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }
    }
}
