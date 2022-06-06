using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.UnitTests.Common;
using InventoryManager.Domain;
using Moq;

namespace InventoryManager.Application.UnitTests.Mocks
{
    public class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "user1",
                    Password = "password1"
                },
                new User
                {
                    Id = 2,
                    Username = "user3",
                    Password = "password3"
                },
                new User
                {
                    Id = 3,
                    Username = "user3",
                    Password = "password3"
                }
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Users);

            mockRepo.Setup(r => r.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(
                    (string username, string password)
                    => Users.FirstOrDefault(i => i.Username == username && i.Password == password));
            

            return mockRepo;

        }
    }
}

