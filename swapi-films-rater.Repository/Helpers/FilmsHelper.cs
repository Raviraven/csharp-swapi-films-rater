using swapi_films_rater.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using swapi_films_rater.Models.ViewModels;

namespace swapi_films_rater.Repository.Helpers
{
    public class FilmsHelper
    {
        public List<FilmListViewModel> GetTitlesAndEpisodes(Film[] films)
        {
            var dropDownList = new List<FilmListViewModel>();
            foreach (var item in films)
            {
                dropDownList.Add(new FilmListViewModel
                {
                    Id = convertStringIdToInt(getLastUrlParam(item.Url)),
                    EpisodeId = item.Episode_id,
                    Title = item.Title
                });
            }
            return dropDownList;
        }

        private int convertStringIdToInt(string Id)
        {
            int result;
            int.TryParse(Id, out result);
            return result;
        }

        private string getLastUrlParam(string url)
        {
            var urlParts = url.Split('/');
            return urlParts[urlParts.Length - 2];
        }
    }
}
