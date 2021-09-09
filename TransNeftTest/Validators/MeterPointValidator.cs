using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class MeterPointValidator : AbstractValidator<MeterPointDTO>
    {
        //private const string _emptyNameMessage = "Имя не может быть пустым.";

        public MeterPointValidator()
        {
            RuleFor(mp => mp.Name).NotEmpty();//.WithMessage(_emptyNameMessage);
            RuleFor(mp => mp.ElictricityMeterId).NotEmpty();
            RuleFor(mp => mp.CurrentTransformerId).NotEmpty();
            RuleFor(mp => mp.VoltageTransformerId).NotEmpty();
            RuleFor(dp => dp.EObjectId).NotEmpty();
            RuleFor(dp => dp.CalcMeterId).NotEmpty();
        }
    }
}
