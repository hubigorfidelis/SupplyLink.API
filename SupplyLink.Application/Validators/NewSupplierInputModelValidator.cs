using FluentValidation;
using SupplyLink.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Validators
{
    public class NewSupplierInputModelValidator : AbstractValidator<NewSupplierInputModel>
    {
        public NewSupplierInputModelValidator()
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
