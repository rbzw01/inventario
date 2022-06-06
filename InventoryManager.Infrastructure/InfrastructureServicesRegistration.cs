using System;
using InventoryManager.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManager.Infrastructure
{
    /// <summary>
    /// Clase para registrara el contexto InventoryManagerDbContext en la injección de dependencia
    /// </summary>
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            //  se inyecta un servicio adicional para la prueba, de forma que exitan usuarios registrados y se pueda utilizar la autenticación
            services.AddScoped<ISampleDataService, SampleDataService>();
            return services;
        }
    }
}

