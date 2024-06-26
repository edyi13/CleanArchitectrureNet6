﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(5).MaximumLength(5);
            RuleFor(x => x.ContactName).NotEmpty().NotNull();
            RuleFor(x => x.Phone).NotEmpty().NotNull();
            RuleFor(x => x.Region).NotEmpty().NotNull();
        }
    }
}
