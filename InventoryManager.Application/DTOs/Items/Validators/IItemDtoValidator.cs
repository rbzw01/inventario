using System;
using FluentValidation;
using InventoryManager.Application.DTOs.Users;

namespace InventoryManager.Application.DTOs.Items.Validators
{
	/// <summary>
    /// Validador de un ItemDto para creación o un futuro actualización de datos
    /// </summary>
    public class IItemDtoValidator : AbstractValidator<IItemDto>
	{
		public IItemDtoValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
			RuleFor(p => p.Type)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
			RuleFor(p => p.ExpirationDate)
				.NotNull()
				.GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} must be after {ComparisonValue}");
		}
	}
}

