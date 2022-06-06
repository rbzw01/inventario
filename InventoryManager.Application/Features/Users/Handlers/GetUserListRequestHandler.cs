using AutoMapper;
using InventoryManager.Application.Contracts;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Users.Requests
{
    /// <summary>
    /// Request que contiene la información de una petición para obtener los usuarios existentes
    /// </summary>
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}

