using InventoryManager.Domain;

namespace InventoryManager.Application.Contracts.Persistence
{
    /// <summary>
    /// Interfaz de acceso al repositorio para los Eventos
    /// </summary>
    public interface IItemEventRepository : IGenericRepository<ItemEvent>
    { }
}

