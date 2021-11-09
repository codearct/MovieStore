using Entities.Model.Performer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.PerformerValidator
{
    class UpdatePerformerModelValidator:AbstractValidator<UpdatePerformerModel>
    {
        public UpdatePerformerModelValidator()
        {
            RuleFor(performer => performer.Name).NotEmpty().When(performer=> !string.IsNullOrEmpty(performer.Name));
            RuleFor(performer => performer.Name).MinimumLength(2);
            RuleFor(performer => performer.Surname).NotEmpty().When(performer => !string.IsNullOrEmpty(performer.Surname));
            RuleFor(performer => performer.Surname).MinimumLength(2);
        }
    }
}
