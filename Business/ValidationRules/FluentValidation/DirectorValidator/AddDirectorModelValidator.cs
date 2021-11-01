using Entities.Model.Director;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.DirectorValidator
{
    public class AddDirectorModelValidator:AbstractValidator<AddDirectorModel>
    {
        public AddDirectorModelValidator()
        {
            RuleFor(director => director.Name).NotEmpty().When(director => !string.IsNullOrEmpty(director.Name));
            RuleFor(director => director.Name).MinimumLength(2);
            RuleFor(director => director.Surname).NotEmpty().When(director => !string.IsNullOrEmpty(director.Surname));
            RuleFor(director => director.Surname).MinimumLength(2);

        }
    }
}
