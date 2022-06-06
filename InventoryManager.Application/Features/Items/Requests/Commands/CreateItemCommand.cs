using System;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Commands
{
    /// <summary>
    /// Request que contiene la información de una petición de creación de un Item
    /// </summary>
    public class CreateItemCommand : IRequest<int>
    {
        public CreateItemDto ItemDto { get; set; }
    }
}

