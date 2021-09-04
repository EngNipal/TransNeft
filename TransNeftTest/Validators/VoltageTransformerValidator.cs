using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class VoltageTransformerValidator : AbstractValidator<VoltageTransformerDTO>
    {
        public VoltageTransformerValidator()
        {
            RuleFor(vt => vt.KTH).NotEmpty();
        }
    }
}
