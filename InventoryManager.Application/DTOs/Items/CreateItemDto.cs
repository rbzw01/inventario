using InventoryManager.Application.DTOs.Common;

namespace InventoryManager.Application.DTOs.Items
{
    /// <summary>
    /// Dto representativo utilizado para la creación de Items del inventario
    /// </summary>
    public class CreateItemDto : IItemDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}