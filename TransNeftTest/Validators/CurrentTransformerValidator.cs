using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class CurrentTransformerValidator : AbstractValidator<CurrentTransformer>
    {
        public CurrentTransformerValidator()
        {
            RuleFor(ct => ct.KTT).NotEmpty();
        }
    }
}
