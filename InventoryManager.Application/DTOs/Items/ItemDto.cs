using InventoryManager.Application.DTOs.Common;
using InventoryManager.Domain;

namespace InventoryManager.Application.DTOs.Items
{
    /// <summary>
    /// Dto de Item para la obtención de datos
    /// </summary>
    public class ItemDto : BaseDto, IItemDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ItemStatus Status { get; set; }
    }
}