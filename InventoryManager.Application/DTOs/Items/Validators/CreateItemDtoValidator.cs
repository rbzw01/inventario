using FluentValidation;

namespace InventoryManager.Application.DTOs.Items.Validators
{
    /// <summary>
    /// Validador de creación de un ItemDto del inventario
    /// </summary>
    public class CreateItemDtoValidator : AbstractValidator<CreateItemDto>
    {
        public CreateItemDtoValidator()
        {
			Include(new IItemDtoValidator());
        }
	}
}

