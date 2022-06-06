using System;
using InventoryManager.Application.Contracts.Infrastructure;

namespace InventoryManager.Api
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var sampleDataService = serviceScope.ServiceProvider.GetService<ISampleDataService>();
            sampleDataService?.Initialize();
        }
    }
}

