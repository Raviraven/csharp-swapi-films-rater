using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace swapi_films_rater.Models.DBModels
{
    public class FilmRate
    {
        [Key]
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
    }
}
