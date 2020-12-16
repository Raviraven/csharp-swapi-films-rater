using System;
using System.Collections.Generic;
using System.Text;

namespace swapi_films_rater.Models.APIModels
{
    public class FilmsContainer
    {
        public int Count { get; set; }
        public Film[] Results { get; set; }
    }
}
