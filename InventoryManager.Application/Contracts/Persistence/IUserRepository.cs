using InventoryManager.Domain;

namespace InventoryManager.Application.Contracts.Persistence
{
    /// <summary>
    /// Interfaz del acceso a datos para los usuarios
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> AuthenticateAsync(string username, string password);
    }
}

