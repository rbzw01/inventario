using FluentValidation.Results;

namespace InventoryManager.Application.Exceptions
{
	/// <summary>
    /// Excepción especifica para validaciones de datos al momento de manejar un comando
    /// </summary>
    public class EntityValidationException : ApplicationException
	{
		public List<string> Errors { get; set; } = new List<string>();

		public EntityValidationException(ValidationResult validationResult)
		{
			Errors.AddRange(from error in validationResult.Errors
							select error.ErrorMessage);
		}
	}
}

