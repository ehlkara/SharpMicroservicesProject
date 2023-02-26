using System;
using FluentValidation;
using SharpCourse.Web.Models.Catalogs;

namespace SharpCourse.Web.Validators
{
    public class CourseCreateInputValidator : AbstractValidator<CourseCreateInput>
    {
        public CourseCreateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course name is not empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is not empty.");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Duraiton is not empty");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is not empty").ScalePrecision(2, 6).WithMessage("Wrong format money.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Select Category");
        }
    }
}

