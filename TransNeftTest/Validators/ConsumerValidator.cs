using FluentValidation;
using FluentValidation.Validators;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class ConsumerValidator : AbstractValidator<ConsumerDTO>
    {
        public ConsumerValidator()
        {
            RuleFor(c => c.SubsidiaryId).NotEmpty();
        }
    }
}