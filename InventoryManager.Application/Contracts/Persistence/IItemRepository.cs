using InventoryManager.Domain;

namespace InventoryManager.Application.Contracts.Persistence
{
    /// <summary>
    /// Interfaz para maneral el repositorio de los Items del inventario
    /// </summary>
    public interface IItemRepository : IGenericRepository<Item>
    {
        /// <summary>
        /// Obtener un item a partir del nombre
        /// </summary>
        /// <param name="name">Nombre del item</param>
        /// <returns>Entidad en caso de ser encontrada</returns>
        Task<Item> GetByName(string name);

        /// <summary>
        /// Obtener los items expirados
        /// </summary>
        /// <returns></returns>
        Task<List<Item>> GetItemExpired();
    }
}

