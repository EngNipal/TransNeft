using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class HoldingValidator : AbstractValidator<Holding>
    {
        public HoldingValidator()
        {
            RuleForEach(h => h.Subsidiaries).SetValidator(new SubsidiaryValidator());
        }
    }
}