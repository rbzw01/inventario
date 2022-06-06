using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;

namespace InventoryManager.Application.Features.Items.Handlers
{
    /// <summary>
    /// Handler base para los handlers de la entidad Item
    /// Permite encapsular las propiedades necesarias para los demás handlers
    /// </summary>
    public abstract class BaseItemRequestHandler
    {
        protected readonly IItemRepository _itemRepository;
        protected readonly IMapper _mapper;

        public BaseItemRequestHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }
    }
}

