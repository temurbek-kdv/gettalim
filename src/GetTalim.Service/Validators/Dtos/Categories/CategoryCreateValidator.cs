﻿using FluentValidation;
using GetTalim.Service.Dtos.Categories;

namespace GetTalim.Service.Validators.Dtos.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name field is required")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotEmpty().NotNull().WithMessage("Description field is required")
            .MinimumLength(3).WithMessage("Description should be more than 3 characters");
    }
}
