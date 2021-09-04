using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class CurrentTransformerValidator : AbstractValidator<CurrentTransformerDTO>
    {
        public CurrentTransformerValidator()
        {
            RuleFor(ct => ct.KTT).NotEmpty();
        }
    }
}
