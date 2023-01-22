using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.CarName).NotEmpty();
            RuleFor(c=>c.CarName).MinimumLength(2);
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c=>c.DailyPrice).GreaterThan(10000);
            RuleFor(c=>c.CarName).Must(StartNameWithA).WithMessage("Araba isimleri A harfi ile başlamalı!");
        }
        //A harfi ile başlayan araba ismi gelirse true dönen metotumuz
        private bool StartNameWithA(string arg)  
        {
            return arg.StartsWith("A");
        }
    }
}
