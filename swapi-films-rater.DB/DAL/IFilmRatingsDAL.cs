using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using swapi_films_rater.Models.DBModels;

namespace swapi_films_rater.DB.DTO
{
    public interface IFilmRatingsDAL
    {
        Task<List<FilmRating>> Get();
        Task<List<FilmRating>> GetByFilmId(int filmId);

        Task<FilmRating> Add(FilmRating filmRating);
    }
}
