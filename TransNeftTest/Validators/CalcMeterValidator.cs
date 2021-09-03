using FluentValidation;
using FluentValidation.Validators;
using System;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class CalcMeterValidator : AbstractValidator<CalcMeter>
    {
        public CalcMeterValidator()
        {
            RuleFor(cm => cm.StartDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.EndDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.DeliveryPoint).NotEmpty();
            RuleFor(cm => cm.MeterPoint).NotEmpty();
        }
    }
}