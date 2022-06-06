namespace InventoryManager.Application.Exceptions
{
	/// <summary>
	/// Excepción especifica en cado de no encontrarse un recurso
	/// </summary>
	public class NotFoundException : ApplicationException
	{
		public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
		{
		}
	}
}

