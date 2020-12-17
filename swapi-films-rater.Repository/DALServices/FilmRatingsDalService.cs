using System;
using System.Collections.Generic;
using System.Text;
using swapi_films_rater.DB.DAL;
using AutoMapper;
using System.Threading.Tasks;
using swapi_films_rater.Models.DBModels;
using swapi_films_rater.Models.ViewModels;

namespace swapi_films_rater.Repository.DALServices
{
    public class FilmRatingsDalService : IFilmRatingsDalService
    {
        private readonly IFilmRatingsDAL _filmRatingsDAL;
        private readonly IMapper _mapper;

        public FilmRatingsDalService(IMapper mapper, IFilmRatingsDAL filmRatingsDAL)
        {
            this._mapper = mapper;
            this._filmRatingsDAL = filmRatingsDAL;
        }

        public async Task<List<FilmRateViewModel>> GetByEpisodeId(int episodeId)
        {
            return _mapper.Map<List<FilmRateViewModel>>(await _filmRatingsDAL.GetByEpisodeId(episodeId));
        }

        public async Task<FilmRateViewModel> Add(FilmRateViewModel filmRate)
        {
            return _mapper.Map<FilmRateViewModel>(await _filmRatingsDAL.Add(_mapper.Map<FilmRate>(filmRate)));
        }
    }
}
