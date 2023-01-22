﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c=>c.CustomerFirstName).NotEmpty();
            RuleFor(c=>c.CustomerFirstName).MinimumLength(2);           
            RuleFor(c=>c.CustomerLastName).NotEmpty();
            RuleFor(c =>c.CustomerLastName).MinimumLength(2);        
        }
    }
}
