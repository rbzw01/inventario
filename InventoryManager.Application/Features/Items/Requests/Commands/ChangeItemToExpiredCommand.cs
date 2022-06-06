using InventoryManager.Application.DTOs.Items;
using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Commands
{
    /// <summary>
    /// Request que contiene la información de una petición de eliminar un Item
    /// </summary>
    public class ChangeItemToExpiredCommand : IRequest
    {
        public ChangeItemToExpired ChangeItemToExpired { get; set; }
    }
}

