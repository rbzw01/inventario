using FluentValidation;

namespace InventoryManager.Application.DTOs.ItemEvents.Validators;

/// <summary>
/// Validador de creación de ItemEventDto
/// </summary>
public class CreateItemEventDtoValidator : AbstractValidator<CreateItemEventDto>
{
    public CreateItemEventDtoValidator()
    {
        // Regla para garantizar que el campo Name tenga datos y no se exceda de un máximo de 50
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        // Regla para garantizar que el campo ItemName tenga datos y no se exceda de un máximo de 50
        RuleFor(p => p.ItemName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
    }
}

