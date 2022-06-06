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
    public class GetItemDetailRequestHandlerTests : ItemBaseUnitTest
    {
        private readonly GetItemDetailRequestHandler _handler;

        public GetItemDetailRequestHandlerTests()
        {
            // Arrange
            _handler = new GetItemDetailRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetItemDetail()
        {
            // Act
            var result = await _handler.Handle(new GetItemDetailRequest { Id = 2 }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ItemDto>();
            result.ShouldNotBeNull();
        }
    }
}

