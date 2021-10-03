using FluentValidation;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    /// <summary> Валидатор трансформатора тока. </summary>
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