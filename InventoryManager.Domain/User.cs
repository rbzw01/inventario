using System;
using InventoryManager.Domain.Common;

namespace InventoryManager.Domain
{
    /// <summary>
    /// Entidad utilizada para la autenticación
    /// </summary>
    public class User:BaseDomainEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

