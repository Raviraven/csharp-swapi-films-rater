using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using swapi_films_rater.Models.DBModels;
using Microsoft.EntityFrameworkCore.Design;

namespace swapi_films_rater.DB
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public DbSet<FilmRate> FilmsRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
