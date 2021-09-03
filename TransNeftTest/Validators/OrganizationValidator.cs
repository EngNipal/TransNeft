using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        private const string _emptyAddressMessage = "Адрес не может быть пустым!";
        private const string _emptyNameMessage = "Имя не может быть пустым!";

        public OrganizationValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage(_emptyNameMessage);
            RuleFor(o => o.Address).NotEmpty().WithMessage(_emptyAddressMessage);
        }
    }
}
