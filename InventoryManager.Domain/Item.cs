using System;
using InventoryManager.Domain.Common;

namespace InventoryManager.Domain
{
    /// <summary>
    /// Iten de inventario
    /// </summary>
    public class Item : BaseDomainEntity
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime ExpirationDate{ get; set; }

        public ItemStatus Status { get; set; }
    }

    public enum ItemStatus
    {
        Active = 0,

        Expired = 1
    }
}

