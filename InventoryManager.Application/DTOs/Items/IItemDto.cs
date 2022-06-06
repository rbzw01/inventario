using InventoryManager.Domain;

namespace InventoryManager.Application.DTOs.Items
{
    /// <summary>
    /// Interfaz representativa de un Item de inventario.
    /// Con el objetivo de generalizar un conjunto de validaciones de DTOs
    /// </summary>
    public interface IItemDto
    {
        string Name { get; set; }

        string Type { get; set; }

        DateTime ExpirationDate { get; set; }
    }
}