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
        public string MovieName { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
