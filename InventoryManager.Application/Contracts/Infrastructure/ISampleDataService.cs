using System;

namespace InventoryManager.Application.Contracts.Infrastructure
{
    /// <summary>
    /// Servicio para cargar datos iniciales de prueba
    /// </summary>
    public interface ISampleDataService
    {
        /// <summary>
        /// Funcionalidad para cargar los datos de prueba al levantar la applicación
        /// </summary>
        void Initialize();
    }
}

