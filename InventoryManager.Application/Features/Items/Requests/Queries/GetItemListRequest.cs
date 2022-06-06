using System;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Items.Requests.Queries
{
    /// <summary>
    /// Request que contiene la información de una petición de obtener los Items existentes
    /// </summary>
    public class GetItemListRequest : IRequest<List<ItemDto>>
    {
    }
}

