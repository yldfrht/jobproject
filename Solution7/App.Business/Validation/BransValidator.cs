using App.Domain.Dtos.Brans;
using App.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Validation
{
    public class BransValidator : AbstractValidator<BransCreateDto>
    {
        public BransValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().MinimumLength(5).MaximumLength(100)
                .WithMessage("{PropertyName} en az 5, en fazla 100 karakter olmalıdır");
        }
    }
}
