using FluentValidation;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class IdentifiedObjectValidator : AbstractValidator<IdentifiedObjectDTO>
    {
        public IdentifiedObjectValidator()
        {
            RuleFor(io => io.Id).NotEmpty();
            RuleFor(io => io.Name).NotEmpty();
            RuleFor(io => io.Address).NotEmpty();
            RuleFor(o => o).SetInheritanceValidator(v =>
            {
                v.Add(new EObjectValidator());
                v.Add(new OrganizationValidator());
            });
        }
    }
}