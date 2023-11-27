using FluentValidation;
using SupplyLink.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Validators
{
    public class NewClientInputModelValidator : AbstractValidator<NewClientInputModel>
    {
        public NewClientInputModelValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty()
              .WithMessage("Campo Obrigatório");

            RuleFor(p => p.Document)
                .NotEmpty()
                .WithMessage("Campo Obrigatório");
            RuleFor(p => p.Login)
                .NotEmpty()
                .WithMessage("Campo Obrigatório");
        }
    }
}
