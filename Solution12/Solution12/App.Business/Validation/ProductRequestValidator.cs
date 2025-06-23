using App.Entity.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Validation
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("{PropertyName} en az 3, en fazla 100 karaktr olmalıdır.");
        }
    }
}
