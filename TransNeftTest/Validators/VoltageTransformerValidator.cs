using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class VoltageTransformerValidator : AbstractValidator<VoltageTransformerDTO>
    {
        public VoltageTransformerValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Number).NotEmpty();
            RuleFor(d => d.CheckDate).GreaterThan(DateTime.MinValue);
            RuleFor(d => d.MeterPointId).NotEmpty();
            RuleFor(vt => vt.KTH).NotEmpty();
        }
    }
}
