using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Model;
using Entities.Model.Director;
using Entities.Model.Performer;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Performer, PerformerViewModel>().ForMember(dest => dest.StarringMovies, opt => opt.MapFrom(src => src.StarringMovies.Select(mp => mp.Movie.Title).ToList()))
                                                      .ForMember(dest=>dest.FullName,opt=>opt.MapFrom(src=>src.Name + " " + src.Surname));

            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
                                              .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                                              .ForMember(dest=> dest.ReleaseDate,opt=>opt.MapFrom(src=>src.ReleaseDate.Date.ToString("dd/MM/yyyy")))
                                              .ForMember(dest => dest.Performers,opt => opt.MapFrom(src => src.Performers.Select(mp=>mp.Performer.Name+" "+mp.Performer.Surname).ToList()));

            CreateMap<AddMovieModel, Movie>().ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => DateTime.Parse(src.ReleaseDate)));

            CreateMap<AddPerformerModel, Performer>();      

            CreateMap<Director, DirectorViewModel>().ForMember(dest => dest.DirectedMovies, opt => opt.MapFrom(src => src.DirectedMovies.Select(m=>m.Title).ToList()))
                                                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));

            CreateMap<AddDirectorModel, Director>();

            CreateMap<MovieViewModel, Movie>();

            CreateMap<Order,OrderViewModel>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                                              .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                                              .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate.Date.ToString("dd/MM/yyyy")));

            CreateMap<Order, OrderByCustomerViewModel>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                                                        .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate.Date.ToString("dd/MM/yyyy")));

            CreateMap<User, CustomerViewModel>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<List<Order>, CustomerViewModel>().ForMember(dest => dest.OrderedMovies, opt => opt.MapFrom(src => src.Select(o=>o.Movie.Title).ToList()))
                                                        .ForMember(dest=>dest.FavoriteGenres,opt=>opt.MapFrom(src=>src.Select(o => o.Movie.Genre.Title).Distinct().ToList()));





        }
    }
}
