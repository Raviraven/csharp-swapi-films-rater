using swapi_films_rater.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using swapi_films_rater.Models.ViewModels;

namespace swapi_films_rater.Repository.Helpers
{
    public class FilmsHelper : IFilmsHelper
    {
        public List<FilmListViewModel> GetTitlesAndEpisodes(Film[] films)
        {
            var dropDownList = new List<FilmListViewModel>();
            if (films == null) return dropDownList;
            foreach (var item in films)
            {
                if (item != null)
                {
                    dropDownList.Add(new FilmListViewModel
                    {
                        UrlId = convertStringIdToInt(getIdParamFromUrl(item.Url)),
                        EpisodeId = item.Episode_id,
                        Title = item.Title
                    });
                }
            }
            return dropDownList;
        }

        protected int convertStringIdToInt(string Id)
        {
            int result;
            int.TryParse(Id, out result);
            return result;
        }

        protected string getIdParamFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            var urlParts = url.Split('/');
            return urlParts[urlParts.Length - 2];
        }
    }
}
