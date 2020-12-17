using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using swapi_films_rater.Models.DBModels;

namespace swapi_films_rater.DB.DAL
{
    public interface IFilmRatingsDAL
    {
        Task<List<FilmRating>> GetByEpisodeId(int filmId);
        Task<FilmRating> Add(FilmRating filmRating);
    }
}
