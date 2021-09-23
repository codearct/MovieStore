using Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.MovieValidator
{
    public class AddMovieModelValidator:AbstractValidator<AddMovieModel>
    {
        public AddMovieModelValidator()
        {
            RuleFor(movie=>movie.Title).NotEmpty();
            RuleFor(movie => movie.Title).MinimumLength(2);
            RuleFor(movie => movie.Price).GreaterThan(0);
            RuleFor(movie => movie.ReleaseDate).GreaterThan(0.ToString());
            RuleFor(movie => movie.ReleaseDate).LessThan(DateTime.Now.ToString());
            RuleFor(movie => movie.GenreId).GreaterThan(0);
            RuleFor(movie => movie.DirectorId).GreaterThan(0);

        }
    }
}
