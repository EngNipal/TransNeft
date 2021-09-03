using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class MeterPointValidator : AbstractValidator<MeterPoint>
    {
        private const string _emptyNameMessage = "Имя не может быть пустым.";

        public MeterPointValidator()
        {
            RuleFor(mp => mp.Name).NotEmpty().WithMessage(_emptyNameMessage);
            RuleFor(mp => mp.ElicticityMeter).SetValidator(new ElictricityMeterValidator());
            RuleFor(mp => mp.CurrentTransformer).SetValidator(new CurrentTransformerValidator());
            RuleFor(mp => mp.VoltageTransformer).SetValidator(new VoltageTransformerValidator());
            RuleFor(dp => dp.Consumer).NotEmpty();
            RuleFor(dp => dp.CalcMeter).NotEmpty();
        }
    }
}
