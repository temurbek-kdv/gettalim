using FluentValidation;
using GetTalim.Service.Dtos.CourseComments;

namespace GetTalim.Service.Validators.Dtos.CourseComments;

public class CourseCommentCreateValidator : AbstractValidator<CourseCommentCreateDto>
{
    public CourseCommentCreateValidator()
    {
        RuleFor(dto => dto.Comment).NotEmpty().NotNull().WithMessage("Comment can not be empty")
           .MaximumLength(300).WithMessage("Comment should be less than 300 characters");
    }

}
