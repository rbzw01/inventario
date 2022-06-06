using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.ItemEvents.Handlers.Commands;
using InventoryManager.Application.Features.ItemEvents.Requests.Commands;
using InventoryManager.Application.UnitTests.ItemEvents.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.ItemEvents.Commands
{
    public class CreateItemEventCommandHandlerTests : ItemEventBaseUnitTest
    {
        private readonly CreateItemEventDto _itemDto;
        private readonly CreateItemEventCommandHandler _handler;

        public CreateItemEventCommandHandlerTests()
        {
            _handler = new CreateItemEventCommandHandler(_mockRepo.Object, _mapper);

            // Arrange
            _itemDto = new CreateItemEventDto
            {
                Name = "ItemEventTestDto",
                ItemId = 2,
                ItemName = "Item2"
            };
        }

        [Fact]
        public async Task Valid_ItemEvent_Added()
        {
            // Arrange
            var result = await _handler.Handle(new CreateItemEventCommand() { ItemEventDto = _itemDto }, CancellationToken.None);

            var itemEvents = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<int>();

            itemEvents.Count.ShouldBe(1);
        }

        [Fact]
        public async Task InValid_ItemEvent_Added()
        {
            // Arrange
            _itemDto.ItemName = string.Empty;

            var ex = await Should.ThrowAsync<EntityValidationException>(
                async () => await _handler.Handle(new CreateItemEventCommand() { ItemEventDto = _itemDto }, CancellationToken.None)
            );

            var ItemEvents = await _mockRepo.Object.GetAll();

            ItemEvents.Count.ShouldBe(0);
            ex.ShouldNotBeNull();
        }
    }
}

