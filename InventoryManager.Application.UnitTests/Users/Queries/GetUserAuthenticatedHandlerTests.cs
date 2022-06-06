using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.Users;
using InventoryManager.Application.Features.Users.Requests;
using InventoryManager.Application.UnitTests.Users.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Users.Queries
{
    public class GetUserAuthenticatedHandlerTests : UserBaseUnitTest
    {
        private GetUserAuthenticatedHandler _handler;

        public GetUserAuthenticatedHandlerTests()
        {
            //Arrange
            _handler = new GetUserAuthenticatedHandler(_mockRepo.Object, _mapper);

        }

        [Fact]
        public async Task Valid_GetUserAuthenticatedTest()
        {
            //Act
            var result = await _handler.Handle(new GetUserAuthenticatedRequest
            {
                UserAuthenticatedDto = new UserAuthenticatedDto
                {
                    Username = "user1",
                    Password = "password1"
                }
            }, CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserDto>();
        }

        [Fact]
        public async Task Invalid_GetUserAuthenticatedTest()
        {
            //Act
            var result = await _handler.Handle(new GetUserAuthenticatedRequest
            {
                UserAuthenticatedDto = new UserAuthenticatedDto
                {
                    Username = "user",
                    Password = "password"
                }
            }, CancellationToken.None);

            //Assert
            result.ShouldBeNull();
        }
    }
}

