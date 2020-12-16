using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.Models.APIModels;

namespace swapi_films_rater.Models
{
    public class FilmDetailsViewModel
    {
        public Film ApiDetails { get; set; }
        public FilmRatingViewModel FilmRating { get; set; }
        public List<FilmRatingViewModel> FilmRatings { get; set; }
    }

    public class FilmRatingViewModel
    {
        public int EpisodeId { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
    }
}
