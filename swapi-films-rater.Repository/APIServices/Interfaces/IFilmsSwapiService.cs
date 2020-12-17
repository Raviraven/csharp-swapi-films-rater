using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using swapi_films_rater.Models.APIModels;

namespace swapi_films_rater.Repository.APIServices
{
    public interface IFilmsSwapiService
    {
        Task<FilmsContainer> Get();
        Task<Film> Get(int Id);
        Task<Film> GetByUrl(string url);
    }
}
