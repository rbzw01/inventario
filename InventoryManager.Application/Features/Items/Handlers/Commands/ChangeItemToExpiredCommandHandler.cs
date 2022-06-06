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
    /// Handler que atiende una solicitud de poner un Item de inventario como
    /// expirado
    /// </summary>
    public class ChangeItemToExpiredCommandHandler : BaseItemRequestHandler, IRequestHandler<ChangeItemToExpiredCommand>
    {
        private readonly IMediator _mediator;

        public ChangeItemToExpiredCommandHandler(IItemRepository itemRepository, IMapper mapper, IMediator mediator) : base(itemRepository, mapper)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ChangeItemToExpiredCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.Get(request.ChangeItemToExpired.Id);

            if (item == null)
                throw new NotFoundException(nameof(Item), request.ChangeItemToExpired.Id);

            item.Status = request.ChangeItemToExpired.Status;

            await _itemRepository.Update(item);

            var itemEventDto = new CreateItemEventDto
            {
                ItemId = item.Id,
                ItemName = item.Name,
                Name = "ItemExpired"
            };

            // Utilizamos el patrón Mediator una vez más para abstraer el manejo de la creación de eventos
            await _mediator.Send(new CreateItemEventCommand {ItemEventDto = itemEventDto});

            return Unit.Value;
        }
    }
}

