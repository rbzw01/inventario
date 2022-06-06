using InventoryManager.Application.DTOs.Common;

namespace InventoryManager.Application.DTOs.Users
{
	/// <summary>
    /// Representación de un Usuario para la obtención de datos
    /// </summary>
    public class UserDto:BaseDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}