using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.UnitTests.Common;
using InventoryManager.Domain;
using Moq;

namespace InventoryManager.Application.UnitTests.Mocks
{
    public class MockItemEventRepository
    {
        public static Mock<IItemEventRepository> GetItemEventRepository()
        {
            var entities = new List<ItemEvent>();

            var mockRepo = new Mock<IItemEventRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(entities);
            mockRepo.Setup(r => r.Add(It.IsAny<ItemEvent>())).ReturnsAsync((ItemEvent entity) =>
            {
                if (entity.Id == 0)
                {
                    var maxId = entities.Any()?entities.Max(i => i.Id):0;
                    entity.Id = maxId + 1;
                }

                entities.Add(entity);
                return entity;
            });

            return mockRepo;

        }
    }
}

