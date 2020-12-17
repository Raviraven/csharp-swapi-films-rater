using swapi_films_rater.Models.APIModels;
using swapi_films_rater.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace swapi_films_rater.Repository.Helpers
{
    public interface IFilmsHelper
    {
        List<FilmListViewModel> GetTitlesAndEpisodes(Film[] films);
    }
}
