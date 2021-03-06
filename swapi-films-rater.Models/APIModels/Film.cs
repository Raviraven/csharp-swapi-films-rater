﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace swapi_films_rater.Models.APIModels
{
    public class Film
    {
        public string Title { get; set; }
        [Display(Name = "Episode No.")]
        public int Episode_id { get; set; }
        [Display(Name ="Opening crawl")]
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [Display(Name = "Release date")]
        public DateTime Release_date { get; set; }
        public string[] Species { get; set; }
        public string[] Starships { get; set; }
        public string[] Vehicles { get; set; }
        public string[] Characters { get; set; }
        public string[] Planets { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
    }
}
