using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class DeliveryPointValidator : AbstractValidator<DeliveryPoint>
    {
        public DeliveryPointValidator()
        {
            RuleFor(dp => dp.Name).NotEmpty();
            RuleFor(dp => dp.MaxPower).GreaterThan(0);
            RuleFor(dp => dp.CalcMeter).SetValidator(new CalcMeterValidator());
            RuleFor(dp => dp.Consumer).NotEmpty();
        }
    }
}