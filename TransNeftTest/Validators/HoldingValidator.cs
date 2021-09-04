using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class HoldingValidator : AbstractValidator<HoldingDTO>
    {
        public HoldingValidator()
        {

        }
    }
}