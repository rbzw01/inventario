using System;
namespace InventoryManager.Application.DTOs.Common
{
	/// <summary>
    /// Entidad Dto base con identificador
    /// </summary>
	public abstract class BaseDto
	{
		/// <summary>
        /// Identificador de la entidad
        /// </summary>
		public int Id { get; set; }
	}
}

