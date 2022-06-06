using System;
using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.ItemEvents.Validators;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.ItemEvents.Requests.Commands;
using InventoryManager.Domain;
using MediatR;

namespace InventoryManager.Application.Features.ItemEvents.Handlers.Commands
{
    /// <summary>
    /// Handler que atiende una solicitud de creación de Evento
    /// </summary>
    public class CreateItemEventCommandHandler : BaseItemEventRequestHandler, IRequestHandler<CreateItemEventCommand, int>
    {
        public CreateItemEventCommandHandler(IItemEventRepository itemEventRepository, IMapper mapper) : base(itemEventRepository, mapper)
        {
        }

        public async Task<int> Handle(CreateItemEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateItemEventDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemEventDto);

            if (!validationResult.IsValid)
                throw new EntityValidationException(validationResult);

            var itemEvent = _mapper.Map<ItemEvent>(request.ItemEventDto);

            itemEvent = await _itemEventRepository.Add(itemEvent);
            return itemEvent.Id;
        }
    }
}

