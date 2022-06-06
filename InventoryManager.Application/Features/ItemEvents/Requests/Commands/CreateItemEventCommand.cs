using System;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.ItemEvents.Requests.Commands
{
    /// <summary>
    /// Request que contiene la información de una petición de Creación de Evento
    /// </summary>
    public class CreateItemEventCommand : IRequest<int>
    {
        public CreateItemEventDto ItemEventDto { get; set; }
    }
}

