using CleanArchitectrure.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Company).NotEmpty().NotNull();
            RuleFor(x => x.Client).NotEmpty().NotNull().MinimumLength(10);
        }
    }
}
