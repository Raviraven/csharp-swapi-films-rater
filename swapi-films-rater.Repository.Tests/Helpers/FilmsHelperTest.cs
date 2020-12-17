using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using swapi_films_rater.Repository.Helpers;
using swapi_films_rater.Models.APIModels;
using swapi_films_rater.Models.ViewModels;

namespace swapi_films_rater.Repository.Tests.Helpers
{
    public class FilmsHelperTest
    {
        [Fact]
        public void GetTitlesAndEpisodes_ReceivesNull_ReturnsEmptyList()
        {
            var filmsHelper = new FilmsHelper();
            var result = filmsHelper.GetTitlesAndEpisodes(null);

            Assert.NotNull(result);
            Assert.IsType<List<FilmListViewModel>>(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void GetTitlesAndEpisodes_ReceivesEmptyTable_ReturnsEmptyList()
        {
            var filmsHelper = new FilmsHelper();
            var filmsTable = new Film[0];

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.NotNull(result);
            Assert.IsType<List<FilmListViewModel>>(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void GetTitlesAndEpisodes_ReceivesTableWithNullValues_ReturnsEmptyList()
        {
            var filmsHelper = new FilmsHelper();
            var filmsTable = new Film[10];

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.NotNull(result);
            Assert.IsType<List<FilmListViewModel>>(result);
            Assert.True(result.Count == 0);
        }


        [Fact]
        public void GetTitlesAndEpisodes_ReceivesTableWithProperData_ReturnsFilledList ()
        {
            var filmsHelper = new FilmsHelper();
            var film = new Film { 
                Url = "some/url/with/id/1/",
                Episode_id = 902,
                Title = "test title"
            };
            var filmsTable = new Film[] { film };
            var expectedList = new List<FilmListViewModel> {
                new FilmListViewModel { UrlId = 1, EpisodeId = 902, Title = "test title"}
            };

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.Equal(expectedList, result);
        }


        [Fact]
        public void GetTitlesAndEpisodes_ReceivesTableWithWrongUrl_ReturnsEpisodeIdEqualsZero()
        {
            var filmsHelper = new FilmsHelper();
            var film = new Film
            {
                Url = "some/url/with/id/",
                Episode_id = 902,
                Title = "test title"
            };
            var filmsTable = new Film[] { film };
            var expectedList = new List<FilmListViewModel> {
                new FilmListViewModel { UrlId = 0, EpisodeId = 902, Title = "test title"}
            };

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.Equal(expectedList, result);
        }


        [Fact]
        public void GetTitlesAndEpisodes_ReceivesTableWithEmptyUrl_ReturnsEpisodeIdEqualsZero()
        {
            var filmsHelper = new FilmsHelper();
            var film = new Film
            {
                Url = "",
                Episode_id = 902,
                Title = "test title"
            };
            var filmsTable = new Film[] { film };
            var expectedList = new List<FilmListViewModel> {
                new FilmListViewModel { UrlId = 0, EpisodeId = 902, Title = "test title"}
            };

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.Equal(expectedList, result);
        }

        [Fact]
        public void GetTitlesAndEpisodes_ReceivesTableWithUrlEqualsNull_ReturnsEpisodeIdEqualsZero()
        {
            var filmsHelper = new FilmsHelper();
            var film = new Film
            {
                Url = null,
                Episode_id = 902,
                Title = "test title"
            };
            var filmsTable = new Film[] { film };
            var expectedList = new List<FilmListViewModel> {
                new FilmListViewModel { UrlId = 0, EpisodeId = 902, Title = "test title"}
            };

            var result = filmsHelper.GetTitlesAndEpisodes(filmsTable);

            Assert.Equal(expectedList, result);
        }
    }
}
