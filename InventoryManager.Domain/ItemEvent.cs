using InventoryManager.Domain.Common;

namespace InventoryManager.Domain
{
    /// <summary>
    /// Se asume inicialmente que los eventos serán un regitro en BD
    /// Aun así se utilizó el patrón mediator para poder crear un nuevo handler
    /// en caso de que se quiera cambiar el destino
    /// </summary>
    public class ItemEvent: BaseDomainEntity
    {
        public string Name { get; set; }

        public string ItemName { get; set; }

        public int ItemId { get; set; }
    }
}

