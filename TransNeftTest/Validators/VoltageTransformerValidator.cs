using FluentValidation;
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
