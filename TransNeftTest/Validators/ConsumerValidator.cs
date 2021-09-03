using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class ConsumerValidator : AbstractValidator<Consumer>
    {
        public ConsumerValidator()
        {
            RuleForEach(c => c.MeterPoints).SetValidator(new MeterPointValidator());
            RuleForEach(c => c.DeliveryPoints).SetValidator(new DeliveryPointValidator());
            RuleFor(c => c.Subsidiary).NotEmpty();
        }
    }
}