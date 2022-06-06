using System;

namespace InventoryManager.Application.DTOs.Users
{
	/// <summary>
    /// Dto utilizado para autenticar un usuario antes de recibir una petición
    /// </summary>
    public class UserAuthenticatedDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}