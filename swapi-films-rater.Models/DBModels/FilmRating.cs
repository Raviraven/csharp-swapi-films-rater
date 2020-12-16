using System;
using System.Collections.Generic;
using System.Text;

namespace swapi_films_rater.Models.DBModels
{
    public class FilmRating
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
    }
}
