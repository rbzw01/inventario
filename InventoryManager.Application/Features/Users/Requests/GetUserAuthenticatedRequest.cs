using System;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Users.Requests
{
    /// <summary>
    /// Request que contiene la información de una petición para autenticar un usuario de una petición
    /// </summary>
    public class GetUserAuthenticatedRequest : IRequest<UserDto>
    {
        public UserAuthenticatedDto UserAuthenticatedDto { get; set; }
    }
}

