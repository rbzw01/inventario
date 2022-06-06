using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.Features.ItemEvents.Handlers.Queries;
using InventoryManager.Application.Features.ItemEvents.Requests.Queries;
using InventoryManager.Application.UnitTests.ItemEvents.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.ItemEvents.Queries
{
    public class GetItemEventListRequestHandlerTests : ItemEventBaseUnitTest
    {
        private readonly GetItemEventListRequestHandler _handler;

        public GetItemEventListRequestHandlerTests()
        {
            // Arrange
            _handler = new GetItemEventListRequestHandler(_mockRepo.Object, _mapper);

        }

        [Fact]
        public async Task GetItemEventList()
        {
            // Arrange
            var entities = await _handler.Handle(new GetItemEventListRequest(), CancellationToken.None);

            entities.ShouldBeOfType<List<ItemEventDto>>();

            entities.Count.ShouldBe(0);
        }
    }
}

