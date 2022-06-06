using System;
using InventoryManager.Application.Contracts.Infrastructure;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Domain;

namespace InventoryManager.Infrastructure
{
    /// <summary>
    /// Servicio adicional par ala realización de pruebas
    /// Permite crear dos usuarios para la autenticación de la API
    /// </summary>
    public class SampleDataService : ISampleDataService
    {
        private readonly IUserRepository _userRepository;

        public SampleDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Initialize()
        {
            _userRepository.Add(new User { Id = 1, Username = "user1", Password = "password1" });
            _userRepository.Add(new User { Id = 2, Username = "user2", Password = "password2" });
        }
    }
}

