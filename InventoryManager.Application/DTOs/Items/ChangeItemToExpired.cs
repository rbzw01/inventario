using InventoryManager.Application.DTOs.Common;
using InventoryManager.Domain;

namespace InventoryManager.Application.DTOs.Items
{
    /// <summary>
    /// Dto de Item para mandar a poner un item como expirado
    /// </summary>
    public class ChangeItemToExpired: BaseDto
    {
        public ItemStatus Status { get; set; }
    }
}