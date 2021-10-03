using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class CalcMeterValidator : AbstractValidator<CalcMeterDto>
    {
        public CalcMeterValidator()
        {
            RuleFor(cm => cm.Id).NotEmpty();
            RuleFor(cm => cm.StartDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.EndDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.EndDate).GreaterThan(cm => cm.StartDate);
            RuleFor(cm => cm.DeliveryPointId).NotEmpty();
            RuleFor(cm => cm.MeterPointId).NotEmpty();
        }
    }
}