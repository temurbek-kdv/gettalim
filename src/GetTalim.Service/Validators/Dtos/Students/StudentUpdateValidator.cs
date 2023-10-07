using FluentValidation;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Student;

namespace GetTalim.Service.Validators.Dtos.Students;

public class StudentUpdateValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().NotNull().WithMessage("Name field is required")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(30).WithMessage("Name must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotEmpty().NotNull().WithMessage("Last name field is required")
            .MinimumLength(3).WithMessage("Last name must be more than 3 characters")
            .MaximumLength(30).WithMessage("Last name must be less than 30 characters");

        RuleFor(dto => dto.IsMale).NotEmpty().NotNull().WithMessage("Is male field is required");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");


        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.ImagePath!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelpers.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
