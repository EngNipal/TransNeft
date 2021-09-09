using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class EObjectValidator : AbstractValidator<EObjectDTO>
    {
        public EObjectValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.ParentOrganizationId).NotEmpty();
        }
    }
}
