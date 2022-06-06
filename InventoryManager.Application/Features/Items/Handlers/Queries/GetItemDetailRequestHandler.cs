using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.DTOs.Users;
using InventoryManager.Application.Features.Items.Requests.Queries;
using MediatR;

namespace InventoryManager.Application.Features.Items.Handlers.Queries
{
    /// <summary>
    /// Handler que atiende una solicitud de obtener un item de inventario y sus detalles
    /// </summary>
    public class GetItemDetailRequestHandler : BaseItemRequestHandler, IRequestHandler<GetItemDetailRequest, ItemDto>
    {
        public GetItemDetailRequestHandler(IItemRepository itemRepository, IMapper mapper)
            : base(itemRepository, mapper)
        {
        }
        public async Task<ItemDto> Handle(GetItemDetailRequest request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.Get(request.Id);
            return _mapper.Map<ItemDto>(item);
        }
    }
}

