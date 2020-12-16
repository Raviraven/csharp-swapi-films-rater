using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using swapi_films_rater.Models.DBModels;

namespace swapi_films_rater.DB
{
    public static class DbSeed
    {
        public static void Seed (SqlContext context)
        {
            //context.Database.EnsureCreated();

            //if (context.FilmsRatings.Any())
            //{
            //    return;
            //}

            //var ratingsToSeed = new List<FilmRating> {
            //    new FilmRating { EpisodeId = 1, MovieName = "", Rating = 4, Username = "Test username 1" },
            //};

            //context.FilmsRatings.AddRange(ratingsToSeed);
            //context.SaveChanges();
        }
    }
}
