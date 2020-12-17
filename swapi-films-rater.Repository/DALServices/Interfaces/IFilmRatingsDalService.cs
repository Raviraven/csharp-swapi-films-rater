using swapi_films_rater.Models.DBModels;
using swapi_films_rater.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swapi_films_rater.Repository.DALServices
{
    public interface IFilmRatingsDalService
    {
        Task<FilmRating> Get();
        Task<List<FilmRateViewModel>> GetByEpisodeId(int episodeId);
        Task<FilmRateViewModel> Add(FilmRateViewModel filmRate);
    }
}
