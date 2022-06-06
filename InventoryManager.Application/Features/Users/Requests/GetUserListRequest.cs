using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Users.Requests
{
    /// <summary>
    /// Request que contiene la información de una petición de obtener los usuarios existentes
    /// </summary>
    public class GetUserListRequest : IRequest<List<UserDto>>
    {
    }
}

