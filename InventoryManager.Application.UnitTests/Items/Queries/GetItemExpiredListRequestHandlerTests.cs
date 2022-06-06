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
    public class GetItemExpiredListRequestHandlerTests : ItemBaseUnitTest
    {
        private readonly GetItemExpiredListRequestHandler _handler;

        public GetItemExpiredListRequestHandlerTests()
        {
            // Arrange
            _handler = new GetItemExpiredListRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetItemExpiredList()
        {
            // Act
            var result = await _handler.Handle(new GetItemExpiredListRequest(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<List<ItemDto>>();
            result.Count.ShouldBe(1);
        }
    }
}

