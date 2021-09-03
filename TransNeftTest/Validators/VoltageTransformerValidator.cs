using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class VoltageTransformerValidator : AbstractValidator<VoltageTransformer>
    {
        public VoltageTransformerValidator()
        {
            RuleFor(vt => vt.KTH).NotEmpty();
        }
    }
}
