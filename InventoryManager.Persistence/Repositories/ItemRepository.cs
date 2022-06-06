using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Persistence.Repositories
{
    /// <summary>
    /// Implementación del Repositorio de Item
    /// </summary>
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(InventoryManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Item> GetByName(string name)
        {
            var result = await _dbContext.Items.SingleOrDefaultAsync(i => i.Name == name);
            return result;
        }

        public async Task<List<Item>> GetItemExpired()
        {
            var result = await _dbContext.Items
                .Where(i => i.Status == ItemStatus.Active && i.ExpirationDate < DateTime.Now)
                .ToListAsync();
            return result;
        }
    }
}

