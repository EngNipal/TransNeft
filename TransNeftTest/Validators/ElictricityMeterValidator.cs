using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class ElictricityMeterValidator : AbstractValidator<ElictricityMeterDTO>
    {
        public ElictricityMeterValidator()
        {
            RuleFor(em => em.Type).NotEmpty();
        }
    }
}