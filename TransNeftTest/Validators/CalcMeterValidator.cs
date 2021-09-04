﻿using FluentValidation;
using FluentValidation.Validators;
using System;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Validators
{
    public class CalcMeterValidator : AbstractValidator<CalcMeterDTO>
    {
        public CalcMeterValidator()
        {
            RuleFor(cm => cm.Id).NotEmpty();
            RuleFor(cm => cm.StartDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.EndDate).GreaterThan(DateTime.MinValue);
            RuleFor(cm => cm.DeliveryPointId).NotEmpty();
            RuleFor(cm => cm.MeterPointId).NotEmpty();
        }
    }
}