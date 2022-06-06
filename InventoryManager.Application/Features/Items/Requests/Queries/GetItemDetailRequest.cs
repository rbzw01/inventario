using InventoryManager.Application.DTOs.Items;
using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Queries
{
    /// <summary>
    /// Request que contiene la información de una petición de obtener un Item en detalles
    /// </summary>
    public class GetItemDetailRequest : IRequest<ItemDto>
    {
        public int Id { get; set; }
    }
}

