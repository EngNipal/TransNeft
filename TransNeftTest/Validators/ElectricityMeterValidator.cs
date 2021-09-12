using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class ElectricityMeterValidator : AbstractValidator<ElectricityMeterDTO>
    {
        public ElectricityMeterValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Number).NotEmpty();
            RuleFor(d => d.CheckDate).GreaterThan(DateTime.MinValue);
            RuleFor(d => d.MeterPointId).NotEmpty();
            RuleFor(em => em.Type).NotEmpty();
        }
    }
}