using System;
using InventoryManager.Application.DTOs.ItemEvents;
using MediatR;

namespace InventoryManager.Application.Features.ItemEvents.Requests.Queries
{
    /// <summary>
    /// Request que contiene la información de una petición de obtener los ItemEvents existentes
    /// </summary>
    public class GetItemEventListRequest : IRequest<List<ItemEventDto>>
    {
    }
}

