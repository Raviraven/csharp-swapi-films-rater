using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swapi_films_rater.Models.ViewModels
{
    public class FilmListViewModel
    {
        public int UrlId { get; set; }
        public int EpisodeId { get; set; }
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var parsedData = (FilmListViewModel)obj;
            if (parsedData == null)
            { 
                return false; 
            }

            if (this.UrlId != parsedData.UrlId
                || this.EpisodeId != parsedData.EpisodeId
                || this.Title != parsedData.Title
                )
            { 
                return false;
            }

            return true;
        }
    }
}
