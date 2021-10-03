﻿using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class EObjectValidator : AbstractValidator<EObjectDto>
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
