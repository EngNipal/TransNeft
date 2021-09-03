using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class SubsidiaryValidator : AbstractValidator<Subsidiary>
    {
        public SubsidiaryValidator()
        {
            RuleForEach(s => s.Consumers).SetValidator(new ConsumerValidator());
            RuleFor(s => s.Holding).NotEmpty();
        }
    }
}