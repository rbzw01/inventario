using System;
using InventoryManager.Application.Contracts.Persistence;
using InventoryManager.Application.UnitTests.Common;
using InventoryManager.Application.UnitTests.Mocks;
using Moq;

namespace InventoryManager.Application.UnitTests.ItemEvents.Commons
{
	public class ItemEventBaseUnitTest : BaseUnitTest
	{
		protected readonly Mock<IItemEventRepository> _mockRepo;

		public ItemEventBaseUnitTest()
		{
			_mockRepo = MockItemEventRepository.GetItemEventRepository();
		}
	}
}

