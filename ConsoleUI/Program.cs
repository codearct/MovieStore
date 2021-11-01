using AutoMapper;
using Business.Concrete;
using Business.Mapper;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MappingProfile>();
            //});

            //PerformerManager performerManager = new PerformerManager(new EfPerformerDal(new Mapper(config)));

            //GetAllPerformersTest(performerManager);
            //GetByPerformerId(performerManager);

            //MovieManager movieManager = new MovieManager(new EfMovieDal(new Mapper(config)));

            //GetByMovieIdTest(movieManager);
            //GetAllMoviesTest(config);


        }

        private static void GetByPerformerId(PerformerManager performerManager)
        {
            var performer = performerManager.GetById(2);
            foreach (var movie in performer.Data.StarringMovies)
            {
                Console.WriteLine(movie);
            }
        }

        private static void GetAllPerformersTest(PerformerManager performerManager)
        {
            var performers = performerManager.GetAll();
            foreach (var performer in performers.Data)
            {
                Console.WriteLine(performer.FullName);
            }
        }

        private static void GetByMovieIdTest(MovieManager movieManager)
        {
            var result = movieManager.GetById(2);
            var movie = result.Data;
            var message = result.Message;

            if (result.Success)
            {
                Console.WriteLine(
                "Movie Title  : {0}\n" +
                "Director     : {1}\n" +
                "Performers   : {2}\n" +
                "             : {3}\n" +
                "Genre        : {4}\n" +
                "Release Date : {5}\n" +
                "Price        : {6}", movie.Title, movie.Director, movie.Performers[0], movie.Performers[1], movie.Genre, movie.ReleaseDate, movie.Price);
            }
            else
            {
                Console.WriteLine(message);
            }
            
        }

        private static void GetAllMoviesTest(MovieManager movieManager)
        {

            foreach (var movie in movieManager.GetAll().Data)
            {
                foreach (var performer in movie.Performers)
                {
                    Console.WriteLine("{0} : {1}", movie.Title, performer);
                }
            }
        }
    }
}
