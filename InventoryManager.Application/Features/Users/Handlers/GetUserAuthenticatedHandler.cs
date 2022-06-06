using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.Users;
using MediatR;

namespace InventoryManager.Application.Features.Users.Requests
{
    /// <summary>
    /// Request que contiene la información de una petición de autenticación
    /// </summary>
    public class GetUserAuthenticatedHandler : IRequestHandler<GetUserAuthenticatedRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserAuthenticatedHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserAuthenticatedRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AuthenticateAsync(request.UserAuthenticatedDto.Username, request.UserAuthenticatedDto.Password);
            var result = _mapper.Map<UserDto>(user);

            if(result != null)
                result.Password = null;

            return result;
        }
    }
}

