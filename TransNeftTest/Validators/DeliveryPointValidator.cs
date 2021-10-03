using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    /// <summary> Валидатор точки поставки электроэнегрии. </summary>
    public class DeliveryPointValidator : AbstractValidator<DeliveryPointDto>
    {
        public DeliveryPointValidator()
        {
            RuleFor(dp => dp.Id).NotEmpty();
            RuleFor(dp => dp.Name).NotEmpty();
            RuleFor(dp => dp.MaxPower).GreaterThan(0);
            RuleFor(dp => dp.EObjectId).NotEmpty();
        }
    }
}