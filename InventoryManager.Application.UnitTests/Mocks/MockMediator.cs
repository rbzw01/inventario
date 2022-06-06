using System.Threading;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.Features.ItemEvents.Handlers.Commands;
using InventoryManager.Application.Features.ItemEvents.Requests.Commands;
using InventoryManager.Application.Features.Items.Requests.Commands;
using MediatR;
using Moq;

namespace InventoryManager.Application.UnitTests.Mocks
{
    public class MockMediator
    {
        public static Mock<IMediator> GetMediator() {

            var mock = new Mock<IMediator>();
            return mock;
        }

        public static Mock<IMediator> RegisterRequest(Mock<IMediator> mock, CreateItemEventCommandHandler handler)
        {
            mock.Setup(m => m.Send(It.IsAny<CreateItemEventCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                (CreateItemEventCommand request, CancellationToken cancellationToken) =>
                {
                    //Act
                    var result = handler.Handle(request, CancellationToken.None).Result;
                    return result;
                })
                //<-- return Task to allow await to continue
                .Verifiable("Notification was not sent.");

            return mock;
        }
    }
}

