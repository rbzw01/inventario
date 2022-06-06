using System;
using AutoMapper;
using InventoryManager.Application.Profiles;

namespace InventoryManager.Application.UnitTests.Common
{
    public class BaseUnitTest
    {
        protected readonly IMapper _mapper;

        public BaseUnitTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
    }
}

