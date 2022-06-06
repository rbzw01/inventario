using System;
using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.DTOs.Items.Validators;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Domain;
using MediatR;

namespace InventoryManager.Application.Features.Items.Handlers.Commands
{
    /// <summary>
    /// Handler que atiende una solicitud de creació de un Item de inventario
    /// </summary>
    public class CreateItemCommandHandler : BaseItemRequestHandler, IRequestHandler<CreateItemCommand, int>
    {
        public CreateItemCommandHandler(IItemRepository itemRepository, IMapper mapper) : base(itemRepository, mapper)
        {
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateItemDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemDto);

            if (!validationResult.IsValid)
                throw new EntityValidationException(validationResult);

            var item = _mapper.Map<Item>(request.ItemDto);
            item.Status = ItemStatus.Active;

            item = await _itemRepository.Add(item);
            return item.Id;
        }
    }
}

