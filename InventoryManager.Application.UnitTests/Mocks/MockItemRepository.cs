using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Domain;
using Moq;

namespace InventoryManager.Application.UnitTests.Mocks
{
    public class MockItemRepository
    {
        public static Mock<IItemRepository> GetItemRepository()
        {
            var entities = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Item1",
                    Type = "Type1",
                    ExpirationDate = DateTime.Now.AddDays(3)
                },
                new Item
                {
                    Id = 2,
                    Name = "Item2",
                    Type = "Type1",
                    ExpirationDate = DateTime.Now.AddDays(-1)
                },
                new Item
                {
                    Id = 3,
                    Name = "Item3",
                    Type = "Type2",
                    ExpirationDate = DateTime.Now.AddDays(2)
                }
            };

            var mockRepo = new Mock<IItemRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(entities);
            mockRepo.Setup(r => r.GetItemExpired()).ReturnsAsync(
                entities.FindAll(i => i.Status == ItemStatus.Active && i.ExpirationDate < DateTime.Now)
                );

            mockRepo.Setup(r => r.Add(It.IsAny<Item>())).ReturnsAsync((Item entity) =>
            {
                if (entity.Id == 0)
                {
                    var maxId = entities.Any() ? entities.Max(i => i.Id) : 0;
                    entity.Id = maxId + 1;
                }

                entities.Add(entity);
                return entity;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))
                .ReturnsAsync(
                    (int id)
                    => entities.FirstOrDefault(i => i.Id == id));

            mockRepo.Setup(r => r.GetByName(It.IsAny<string>()))
                .ReturnsAsync(
                    (string name)
                    => entities.FirstOrDefault(i => i.Name == name));

            mockRepo.Setup(r => r.Delete(It.IsAny<Item>()))
                .Callback((Item entity) =>
                {
                    entities.RemoveAll(i => i.Id == entity.Id);
                });
            return mockRepo;

        }
    }
}

