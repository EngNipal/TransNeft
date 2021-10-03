using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class CurrentTransformerValidator : AbstractValidator<CurrentTransformerDto>
    {
        public CurrentTransformerValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Number).NotEmpty();
            RuleFor(d => d.CheckDate).GreaterThan(DateTime.MinValue);
            RuleFor(d => d.MeterPointId).NotEmpty();
            RuleFor(ct => ct.KTT).NotEmpty();
        }
    }
}