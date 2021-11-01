using AutoMapper;
using FluentValidation;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Model;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation.MovieValidator;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;
        private readonly IMapper _mapper;

        public MovieManager(IMovieDal movieDal, IMapper mapper)
        {
            _movieDal = movieDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddMovieModelValidator))]
        [CacheRemoveAspect("IMovieService.Get")]
        [TransactionScopeAspect]
        public IResult Add(AddMovieModel model)
        {

            var movie = _movieDal.Get(m => m.Title == model.Title);

            IResult result = BusinessRules.Run(CheckIfMovieAlreadyExists(movie));
            if (result != null)
            {
                return result;
            }


            movie = _mapper.Map<Movie>(model);

            _movieDal.Add(movie);

            return new SuccessResult(Messages.MovieAdded);
        }

        [CacheRemoveAspect("IMovieService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(int id)
        {
            var movie = _movieDal.Get(m => m.Id == id);

            IResult result = BusinessRules.Run(CheckIfMovieIsNotExist(movie));
            if (result != null)
            {
                return result;
            }

            movie.IsActive = false;

            return new SuccessResult(Messages.DeletedMovie);
        }

        [CacheAspect]
        public IDataResult<List<MovieViewModel>> GetAll()
        {
            var movies = _movieDal.GetAll();

            List<MovieViewModel> movieVMs = _mapper.Map<List<MovieViewModel>>(movies);

            return new SuccessDataResult<List<MovieViewModel>>(movieVMs);
        }

        [CacheAspect]
        public IDataResult<MovieViewModel> GetById(int id)
        {
            var movie = _movieDal.Get(m=>m.Id==id);

            if (movie is null)
            {
                return new ErrorDataResult<MovieViewModel>(Messages.NotExistMovie);
            }

            MovieViewModel movieVM = _mapper.Map<MovieViewModel>(movie);

            return new SuccessDataResult<MovieViewModel>(movieVM);
        }
        [CacheAspect]
        public IDataResult<Movie> Get(int id)
        {
            var movie = _movieDal.Get(id);

            if (movie is null)
            {
                return new ErrorDataResult<Movie>(Messages.NotExistMovie);
            }

            return new SuccessDataResult<Movie>(movie);
        }

        [ValidationAspect(typeof(UpdateMovieModelValidator))]
        [CacheRemoveAspect("IMovieService.Get")]
        [TransactionScopeAspect]
        public IResult Update(int id, UpdateMovieModel model)
        {
            var movie = _movieDal.Get(m => m.Id == id);

            IResult result = BusinessRules.Run(CheckIfMovieIsNotExist(movie));
            if (result!=null)
            {
                return result;
            }

            movie.Title = string.IsNullOrEmpty(model.Title) ? movie.Title : model.Title;
            movie.Price = model.Price == default ? movie.Price : model.Price;
            movie.ReleaseDate = string.IsNullOrEmpty(model.ReleaseDate) ? movie.ReleaseDate : DateTime.Parse(model.ReleaseDate);
            movie.GenreId = model.GenreId == default ? movie.GenreId : model.GenreId;
            movie.DirectorId = model.DirectorId == default ? movie.DirectorId : model.DirectorId;

            _movieDal.Update(movie);

            return new SuccessResult(Messages.UpdatedMovie);
        }
        private IResult CheckIfMovieIsNotExist(Movie movie)
        {
            if (movie is null)
            {
                return new ErrorResult(Messages.NotExistMovie);
            }
            return new SuccessResult();
        }
        private IResult CheckIfMovieAlreadyExists(Movie movie)
        {
            if (movie is not null)
            {
                return new ErrorResult(Messages.ExistingMovie);
            }
            return new SuccessResult();
        }

        
    }
}
