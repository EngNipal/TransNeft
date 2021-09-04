using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class SubsidiaryValidator : AbstractValidator<SubsidiaryDTO>
    {
        public SubsidiaryValidator()
        {
            RuleFor(s => s.HoldingId).NotEmpty();
        }
    }
}