using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace swapi_films_rater.Models.ViewModels
{
    public class FilmRateViewModel
    {
        public int UrlId { get; set; }
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        [Required]
        [Range(0, 10)]
        public int? Rate { get; set; }
        [Required]
        public string Username { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var parsedObj = (FilmRateViewModel)obj;

            if (parsedObj == null) return false;

            if (this.UrlId != parsedObj.UrlId
                || this.EpisodeId != parsedObj.EpisodeId
                || this.Title != parsedObj.Title
                || this.Rate != parsedObj.Rate
                || this.Username != parsedObj.Username)
                return false;

            return true;
        }
    }
}
