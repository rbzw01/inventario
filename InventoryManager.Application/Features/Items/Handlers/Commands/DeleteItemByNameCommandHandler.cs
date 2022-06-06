using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.ItemEvents.Requests.Commands;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Domain;
using MediatR;

namespace InventoryManager.Application.Features.Items.Handlers.Commands
{
    /// <summary>
    /// Handler que atiende una solicitud de eliminar un Item de inventario
    /// </summary>
    public class DeleteItemByNameCommandHandler : BaseItemRequestHandler, IRequestHandler<DeleteItemByNameCommand>
    {
        private readonly IMediator _mediator;

        public DeleteItemByNameCommandHandler(IItemRepository itemRepository, IMapper mapper, IMediator mediator) : base(itemRepository, mapper)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteItemByNameCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByName(request.Name);

            if (item == null)
                throw new NotFoundException(nameof(Item), request.Name);

            await _itemRepository.Delete(item);

            var itemEventDto = new CreateItemEventDto
            {
                ItemId = item.Id,
                ItemName = item.Name,
                Name = "ItemRemoved"
            };

            // Utilizamos el patrón Mediator una vez más para abstraer el manejo de la creación de eventos
            await _mediator.Send(new CreateItemEventCommand {ItemEventDto = itemEventDto});

            return Unit.Value;
        }
    }
}

