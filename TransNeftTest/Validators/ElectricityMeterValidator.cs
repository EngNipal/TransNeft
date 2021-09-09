using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class ElectricityMeterValidator : AbstractValidator<ElectricityMeterDTO>
    {
        public ElectricityMeterValidator()
        {
            RuleFor(em => em.Type).NotEmpty();
        }
    }
}