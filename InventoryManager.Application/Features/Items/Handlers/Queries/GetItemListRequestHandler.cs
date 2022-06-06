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
    public class GetItemListRequestHandler : BaseItemRequestHandler, IRequestHandler<GetItemListRequest, List<ItemDto>>
    {
        public GetItemListRequestHandler(IItemRepository itemRepository, IMapper mapper)
            :base(itemRepository, mapper)
        {
        }

        public async Task<List<ItemDto>> Handle(GetItemListRequest request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAll();
            return _mapper.Map<List<ItemDto>>(items);
        }
    }
}

