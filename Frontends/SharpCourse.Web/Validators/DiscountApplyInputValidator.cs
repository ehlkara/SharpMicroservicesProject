using System;
using FluentValidation;
using SharpCourse.Web.Models.Discounts;

namespace SharpCourse.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Discount code area is not empty");
        }
    }
}

