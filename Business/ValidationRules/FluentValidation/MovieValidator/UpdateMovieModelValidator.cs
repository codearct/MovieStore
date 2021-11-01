using Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.MovieValidator
{
    public class UpdateMovieModelValidator:AbstractValidator<UpdateMovieModel>
    {
        public UpdateMovieModelValidator()
        {
            RuleFor(movie => movie.Title).MinimumLength(2);
            RuleFor(movie => movie.Price).GreaterThan(0).When(movie=>movie.Price!=default);
            RuleFor(movie => movie.ReleaseDate).GreaterThan(0.ToString());
            RuleFor(movie => movie.ReleaseDate).LessThan(DateTime.Now.ToString());
            RuleFor(movie => movie.GenreId).GreaterThan(0).When(movie => movie.GenreId != default);
            RuleFor(movie => movie.DirectorId).GreaterThan(0).When(movie => movie.DirectorId != default);
        }
    }
}
