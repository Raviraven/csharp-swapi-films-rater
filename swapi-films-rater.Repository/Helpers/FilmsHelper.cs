using swapi_films_rater.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace swapi_films_rater.Repository.Helpers
{
    public class FilmsHelper
    {
        public Dictionary<int, string> GetTitlesAndEpisodes(Film[] films)
        {
            Dictionary<int, string> dropDownList = new Dictionary<int, string>();
            foreach (var item in films)
            {
                dropDownList.Add(item.Episode_id, item.Title);
            }
            return dropDownList;
        }
    }
}
