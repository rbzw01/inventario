using InventoryManager.Application.DTOs.Common;

namespace InventoryManager.Application.DTOs.ItemEvents
{
    /// <summary>
    /// Dto representativo de un evento
    /// </summary>
    public class ItemEventDto : BaseDto
    {
        public string Name { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }
    }
}