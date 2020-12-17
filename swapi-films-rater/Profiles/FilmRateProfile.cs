using AutoMapper;
using swapi_films_rater.Models.DBModels;
using swapi_films_rater.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace swapi_films_rater.Repository.Profiles
{
    public class FilmRateProfile : Profile
    {
        public FilmRateProfile()
        {
            this.CreateMap<FilmRate, FilmRateViewModel>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating));
            
            this.CreateMap<FilmRateViewModel, FilmRate>()
                .ForMember(dest=>dest.Rating, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.EpisodeId, opt => opt.MapFrom(src => src.EpisodeId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
        }
    }
}
