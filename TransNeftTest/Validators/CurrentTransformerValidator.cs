using FluentValidation;
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
