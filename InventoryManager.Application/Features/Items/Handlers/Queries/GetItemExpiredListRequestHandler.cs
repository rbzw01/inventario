using System;
using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.DTOs.Users;
using InventoryManager.Application.Features.Items.Requests.Queries;
using MediatR;

namespace InventoryManager.Application.Features.Items.Handlers.Queries
{
    /// <summary>
    /// Handler que atiende una solicitud de obtener los items de inventarios existentes
    /// </summary>
    public class GetItemExpiredListRequestHandler : BaseItemRequestHandler, IRequestHandler<GetItemExpiredListRequest, List<ItemDto>>
    {
        public GetItemExpiredListRequestHandler(IItemRepository itemRepository, IMapper mapper)
            :base(itemRepository, mapper)
        {
        }

        public async Task<List<ItemDto>> Handle(GetItemExpiredListRequest request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetItemExpired();
            return _mapper.Map<List<ItemDto>>(items);
        }
    }
}

