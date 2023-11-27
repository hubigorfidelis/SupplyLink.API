using FluentValidation;
using SupplyLink.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Application.Validators
{
    public class UpdateSupplierInputModelValidator : AbstractValidator<UpdateSupplierInputModel>
    {
        public UpdateSupplierInputModelValidator()
        {
               RuleFor(p => p.Name)
                .NotEmpty();

               RuleFor(p=> p.Status) 
                .NotEmpty(); 
        }
    }
}
