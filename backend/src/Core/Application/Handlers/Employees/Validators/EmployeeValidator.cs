using Application.Handlers.Employees.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Employees.Validators
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Employee first name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Employee last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Employee Email is required");
        }
    }

    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Employee ID is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Employee first name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Employee last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Employee Email is required");
        }
    }
}
