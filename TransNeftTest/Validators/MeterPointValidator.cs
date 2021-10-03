using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    /// <summary> Валидатор точки измерения электроэнергии. </summary>
    public class MeterPointValidator : AbstractValidator<MeterPointDto>
    {
        private const string _emptyNameMessage = "Имя не может быть пустым.";

        public MeterPointValidator()
        {
            RuleFor(mp => mp.Name).NotEmpty().WithMessage(_emptyNameMessage);
            RuleFor(mp => mp.ElectricityMeterId).NotEmpty();
            RuleFor(mp => mp.CurrentTransformerId).NotEmpty();
            RuleFor(mp => mp.VoltageTransformerId).NotEmpty();
            RuleFor(dp => dp.EObjectId).NotEmpty();
            RuleFor(dp => dp.CalcMeterId).NotEmpty();
        }
    }
}
