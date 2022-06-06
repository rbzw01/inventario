using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.Features.ItemEvents.Handlers.Commands;
using InventoryManager.Application.Features.Items.Handlers.Commands;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Application.UnitTests.Items.Commons;
using InventoryManager.Application.UnitTests.Mocks;
using InventoryManager.Domain;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Items.Commands
{
    public class ChangeItemToExpiredCommandHandlerTests : ItemBaseUnitTest
    {
        private Mock<IMediator> _mockMediator;
        private ChangeItemToExpiredCommandHandler _handler;

        public ChangeItemToExpiredCommandHandlerTests()
        {
            _mockMediator = MockMediator.GetMediator();
            _handler = new ChangeItemToExpiredCommandHandler(_mockRepo.Object, _mapper, _mockMediator.Object);
        }

        [Fact]
        public async Task GetItemListTest()
        {
            //Arrange
            var mockRepoItemEvent = MockItemEventRepository.GetItemEventRepository();
            var handlerItemEvent = new CreateItemEventCommandHandler(mockRepoItemEvent.Object, _mapper);

            MockMediator.RegisterRequest(_mockMediator, handlerItemEvent);
            var id = 1;

            //Act
            await _handler.Handle(new ChangeItemToExpiredCommand
            {
                ChangeItemToExpired = new DTOs.Items.ChangeItemToExpired{
                    Id = id,
                    Status = ItemStatus.Expired
                }
            }, CancellationToken.None);

            //Assert
            _mockRepo.Object.Get(id).Result.Status.ShouldBe(ItemStatus.Expired);
        }
    }
}

