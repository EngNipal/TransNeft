using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class DeliveryPointValidator : AbstractValidator<DeliveryPointDTO>
    {
        public DeliveryPointValidator()
        {
            RuleFor(dp => dp.Id).NotEmpty();
            RuleFor(dp => dp.Name).NotEmpty();
            RuleFor(dp => dp.MaxPower).GreaterThan(0);
            RuleFor(dp => dp.CalcMeterId).NotEmpty();
            RuleFor(dp => dp.EObjectId).NotEmpty();
        }
    }
}