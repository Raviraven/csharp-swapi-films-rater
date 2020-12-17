using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swapi_films_rater.Models.ViewModels
{
    public class FilmRateViewModel
    {
        public int EpisodeId { get; set; }
        public string MovieName { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
    }
}
