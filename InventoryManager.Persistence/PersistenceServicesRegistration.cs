using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManager.Persistence
{
    /// <summary>
    /// Clase para registrara el contexto InventoryManagerDbContext en la injección de dependencia
    /// </summary>
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagerDbContext>(options =>

            options.UseInMemoryDatabase("CinemaDb")
                    .EnableSensitiveDataLogging()
                    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemEventRepository, ItemEventRepository>();
            //  se inyecta un servicio adicional para la prueba, de forma que exitan usuarios registrados y se pueda utilizar la autenticación
            return services;
        }
    }
}

