using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    /// <summary> Валидатор организации. </summary>
    public class OrganizationValidator : AbstractValidator<OrganizationDto>
    {
        private const string _emptyAddressMessage = "Адрес не может быть пустым!";
        private const string _emptyNameMessage = "Имя не может быть пустым!";

        public OrganizationValidator()
        {
            RuleFor(o => o.Id).NotEmpty();
            RuleFor(o => o.Name).NotEmpty().WithMessage(_emptyNameMessage);
            RuleFor(o => o.Address).NotEmpty().WithMessage(_emptyAddressMessage);
        }
    }
}