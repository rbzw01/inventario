using System;
using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.Features.ItemEvents.Requests.Queries;
using MediatR;

namespace InventoryManager.Application.Features.ItemEvents.Handlers.Queries
{
    /// <summary>
    /// Handler que atiende una solicitud de obtener los ItemEvents de inventarios existentes
    /// </summary>
    public class GetItemEventListRequestHandler : BaseItemEventRequestHandler, IRequestHandler<GetItemEventListRequest, List<ItemEventDto>>
    {
        public GetItemEventListRequestHandler(IItemEventRepository itemEventRepository, IMapper mapper)
            : base(itemEventRepository, mapper)
        {
        }

        public async Task<List<ItemEventDto>> Handle(GetItemEventListRequest request, CancellationToken cancellationToken)
        {
            var ItemEvents = await _itemEventRepository.GetAll();
            return _mapper.Map<List<ItemEventDto>>(ItemEvents);
        }
    }
}

