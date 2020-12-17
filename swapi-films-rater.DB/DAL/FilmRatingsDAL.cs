using Microsoft.EntityFrameworkCore;
using swapi_films_rater.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi_films_rater.DB.DAL
{
    public class FilmRatingsDAL : IFilmRatingsDAL
    {
        private readonly SqlContext _context;

        public FilmRatingsDAL(SqlContext context)
        {
            _context = context;
        }
            
        public async Task<FilmRating> Add(FilmRating filmRating)
        {
            try
            {
                _context.Add(filmRating);
                await _context.SaveChangesAsync();
                return filmRating;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<FilmRating>> GetByEpisodeId(int filmId)
        {
                return await _context.FilmsRatings
                    .Where(n => n.EpisodeId == filmId)
                    .ToListAsync();
        }
    }
}
