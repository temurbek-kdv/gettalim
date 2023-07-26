using FluentValidation;
using GetTalim.Service.Dtos.StudentsAuth;

namespace GetTalim.Service.Validators.Dtos.Students;

public class StudentLoginValidator : AbstractValidator<StudentLoginDto>
{
    public StudentLoginValidator()
    {
        RuleFor(dto => dto.Email).EmailAddress().WithMessage("Write correct email address");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
             .WithMessage("Password is not strong password!");
    }
}
