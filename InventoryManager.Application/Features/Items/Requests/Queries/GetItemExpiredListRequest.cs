using InventoryManager.Application.DTOs.Items;
using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Queries
{
    /// <summary>
    /// Request que contiene la información de una petición de obtener los Items
    /// existentes que se encuentran expirados y en un estado Activo
    /// </summary>
    public class GetItemExpiredListRequest : IRequest<List<ItemDto>>
    {
    }
}

