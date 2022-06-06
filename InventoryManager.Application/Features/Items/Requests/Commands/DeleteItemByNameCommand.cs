using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Commands
{
    /// <summary>
    /// Request que contiene la información de una petición de eliminar un Item
    /// </summary>
    public class DeleteItemByNameCommand : IRequest
    {
        public string Name { get; set; }
    }
}

