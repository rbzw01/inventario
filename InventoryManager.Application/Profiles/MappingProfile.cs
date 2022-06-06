using System;
using AutoMapper;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.DTOs.Users;
using InventoryManager.Domain;

namespace InventoryManager.Application.Profiles
{
	/// <summary>
    /// Perfil de mapeo para la utilización del automapper
    /// </summary>
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<User, UserAuthenticatedDto>().ReverseMap();

			CreateMap<Item, ItemDto>().ReverseMap();
			CreateMap<Item, CreateItemDto>().ReverseMap();

			CreateMap<ItemEvent, ItemEventDto>().ReverseMap();
			CreateMap<ItemEvent, CreateItemEventDto>().ReverseMap();
		}
	}
}

