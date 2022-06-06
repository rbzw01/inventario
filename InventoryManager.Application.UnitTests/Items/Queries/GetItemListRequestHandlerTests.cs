using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.Features.Items.Handlers.Queries;
using InventoryManager.Application.Features.Items.Requests.Queries;
using InventoryManager.Application.UnitTests.Items.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Items.Queries
{
    public class GetItemListRequestHandlerTests : ItemBaseUnitTest
    {
        private readonly GetItemListRequestHandler _handler;

        public GetItemListRequestHandlerTests()
        {
            // Arrange
            _handler = new GetItemListRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetItemList()
        {
            // Act
            var result = await _handler.Handle(new GetItemListRequest(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<List<ItemDto>>();
            result.Count.ShouldBe(3);
        }
    }
}

