using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Domain;

namespace InventoryManager.Persistence.Repositories
{
    /// <summary>
    /// Implementación del Repositorio de ItemEvent
    /// </summary>
    public class ItemEventRepository : GenericRepository<ItemEvent>, IItemEventRepository
    {
        public ItemEventRepository(InventoryManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}

