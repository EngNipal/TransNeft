using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class DeviceValidator : AbstractValidator<DeviceDTO>
    {
        public DeviceValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Number).NotEmpty();
            RuleFor(d => d.CheckDate).GreaterThan(DateTime.MinValue);
            RuleFor(d => d.MeterPointId).NotEmpty();
            RuleFor(d => d).SetInheritanceValidator(v =>
            {
                v.Add(new ElictricityMeterValidator());
                v.Add(new CurrentTransformerValidator());
                v.Add(new VoltageTransformerValidator());
            });
        }
    }
}
