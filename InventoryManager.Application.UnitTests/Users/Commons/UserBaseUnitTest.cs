using System;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.UnitTests.Common;
using InventoryManager.Application.UnitTests.Mocks;
using Moq;

namespace InventoryManager.Application.UnitTests.Users.Commons
{
    public class UserBaseUnitTest : BaseUnitTest
	{
		protected readonly Mock<IUserRepository> _mockRepo;

		public UserBaseUnitTest()
		{
			_mockRepo = MockUserRepository.GetUserRepository();
		}
	}
}

