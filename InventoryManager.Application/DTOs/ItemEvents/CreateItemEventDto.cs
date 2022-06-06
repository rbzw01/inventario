using System;
namespace InventoryManager.Application.DTOs.ItemEvents
{
	/// <summary>
    /// Dto utilizado para recibir la información de la creación de un evento
    /// </summary>
	public class CreateItemEventDto
	{
		public string Name { get; set; }

		public int ItemId { get; set; }

        public string ItemName { get; set; }
    }
}