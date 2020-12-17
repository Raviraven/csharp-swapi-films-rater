using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.Models.APIModels;

namespace swapi_films_rater.Models.ViewModels
{
    public class FilmDetailsViewModel
    {
        public int UrlId { get; set; }
        public Film ApiDetails { get; set; }
        public List<FilmRateViewModel> FilmRatings { get; set; }
    }

}
