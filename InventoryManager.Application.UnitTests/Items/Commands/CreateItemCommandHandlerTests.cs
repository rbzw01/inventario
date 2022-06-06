using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.Items.Handlers.Commands;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Application.UnitTests.Items.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Items.Commands
{
    public class CreateItemCommandHandlerTests : ItemBaseUnitTest
    {
        private readonly CreateItemDto _itemDto;
        private readonly CreateItemCommandHandler _handler;

        public CreateItemCommandHandlerTests()
        {
            _handler = new CreateItemCommandHandler(_mockRepo.Object, _mapper);

            // Arrange
            _itemDto = new CreateItemDto
            {
                Name = "ItemTestDto",
                ExpirationDate = DateTime.Now.AddDays(1),
                Type = "Type1"
            };
        }

        [Fact]
        public async Task Valid_Item_Added()
        {
            // Arrange
            var result = await _handler.Handle(new CreateItemCommand() { ItemDto = _itemDto }, CancellationToken.None);

            var Items = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<int>();

            Items.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Item_Added()
        {
            // Arrange
            _itemDto.ExpirationDate = DateTime.Now.AddDays(-5);

            var ex = await Should.ThrowAsync<EntityValidationException>(
                async () => await _handler.Handle(new CreateItemCommand() { ItemDto = _itemDto }, CancellationToken.None)
            );

            var Items = await _mockRepo.Object.GetAll();

            Items.Count.ShouldBe(3);
            ex.ShouldNotBeNull();
        }
    }
}

