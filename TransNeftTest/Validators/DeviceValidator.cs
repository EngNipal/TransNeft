using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class DeviceValidator : AbstractValidator<DeviceDto>
    {
        public DeviceValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Number).NotEmpty();
            RuleFor(d => d.CheckDate).GreaterThan(DateTime.MinValue);
            RuleFor(d => d.MeterPointId).NotEmpty();
            RuleFor(d => d).SetInheritanceValidator(v =>
            {
                v.Add(new ElectricityMeterValidator());
                v.Add(new CurrentTransformerValidator());
                v.Add(new VoltageTransformerValidator());
            });
        }
    }
}