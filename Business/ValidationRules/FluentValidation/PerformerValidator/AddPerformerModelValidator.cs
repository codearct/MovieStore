using Entities.Model.Performer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.PerformerValidator
{
    public class AddPerformerModelValidator:AbstractValidator<AddPerformerModel>
    {
        public AddPerformerModelValidator()
        {
            RuleFor(performer => performer.Name).NotEmpty();
            RuleFor(performer => performer.Name).MinimumLength(2);
            RuleFor(performer => performer.Surname).NotEmpty();
            RuleFor(performer => performer.Surname).MinimumLength(2);
        }
    }
}
