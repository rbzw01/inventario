using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.Features.ItemEvents.Handlers.Commands;
using InventoryManager.Application.Features.Items.Handlers.Commands;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Application.UnitTests.Items.Commons;
using InventoryManager.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Items.Commands
{
    public class DeleteItemByNameCommandHandlerTests : ItemBaseUnitTest
    {
        private Mock<IMediator> _mockMediator;

        public DeleteItemByNameCommandHandlerTests()
        {
            _mockMediator = MockMediator.GetMediator();
        }

        [Fact]
        public async Task GetItemListTest()
        {
            //Arrange
            var mockRepoItemEvent = MockItemEventRepository.GetItemEventRepository();
            var handlerItemEvent = new CreateItemEventCommandHandler(mockRepoItemEvent.Object, _mapper);

            MockMediator.RegisterRequest(_mockMediator, handlerItemEvent);

            var handler = new DeleteItemByNameCommandHandler(_mockRepo.Object, _mapper, _mockMediator.Object);

            //Act
            var result = await handler.Handle(new DeleteItemByNameCommand { Name = "Item2" }, CancellationToken.None);

            //Assert
            _mockRepo.Object.GetAll().Result.Count.ShouldBe(2);
        }
    }
}

