using FluentValidation;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.StudentsAuth;

namespace GetTalim.Service.Validators.Dtos.Students;

public class StudentUpdateValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateValidator()
    {
        RuleFor(dto => dto.IsMale).NotEmpty().NotNull().WithMessage("Is male field is required");
        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");
       

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelpers.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
