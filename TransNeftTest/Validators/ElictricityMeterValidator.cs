using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class ElictricityMeterValidator : AbstractValidator<ElictricityMeter>
    {
        public ElictricityMeterValidator()
        {
            RuleFor(em => em.Type).NotEmpty();
        }
    }
}