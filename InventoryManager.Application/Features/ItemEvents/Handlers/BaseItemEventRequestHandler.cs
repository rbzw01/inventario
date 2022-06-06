using AutoMapper;
using InventoryManager.Application.Contracts.Persistence;

namespace InventoryManager.Application.Features.ItemEvents.Handlers
{
    /// <summary>
    /// Handler base para los handlers de la entidad ItemEvent
    /// Permite encapsular las propiedades necesarias para los demás handlers
    /// </summary>
    public abstract class BaseItemEventRequestHandler
    {
        protected readonly IItemEventRepository _itemEventRepository;
        protected readonly IMapper _mapper;

        public BaseItemEventRequestHandler(IItemEventRepository itemEventRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itemEventRepository = itemEventRepository;
        }
    }
}

