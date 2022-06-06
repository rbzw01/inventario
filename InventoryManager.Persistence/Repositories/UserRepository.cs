using System;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Persistence.Repositories
{
    /// <summary>
    /// Implementación del Repositorio de User
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(InventoryManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(i => i.Username == username && i.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            return user;
        }
    }
}

