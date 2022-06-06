using System;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.UnitTests.Common;
using InventoryManager.Application.UnitTests.Mocks;
using Moq;

namespace InventoryManager.Application.UnitTests.Items.Commons
{
	public class ItemBaseUnitTest : BaseUnitTest
	{
		protected readonly Mock<IItemRepository> _mockRepo;

		public ItemBaseUnitTest()
		{
			_mockRepo = MockItemRepository.GetItemRepository();
		}
	}
}

