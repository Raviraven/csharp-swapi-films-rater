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
        private readonly string _connectionString;

        //public SqlContext(string connectionString) 
        //{
        //    _connectionString = connectionString;
        //}
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<FilmRating> FilmsRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FilmRating>()
            //    .HasKey("Id");

            //DbSeed.Seed(modelBuilder);
        }
    }
}
