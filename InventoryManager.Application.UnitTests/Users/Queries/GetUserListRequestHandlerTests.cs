using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.Users;
using InventoryManager.Application.Features.Users.Requests;
using InventoryManager.Application.UnitTests.Users.Commons;
using Shouldly;
using Xunit;

namespace InventoryManager.Application.UnitTests.Users.Queries
{
    public class GetUserListRequestHandlerTests : UserBaseUnitTest
    {
        private GetUserListRequestHandler _handler;

        public GetUserListRequestHandlerTests()
        {
            //Arrange
            _handler = new GetUserListRequestHandler(_mockRepo.Object, _mapper);
        }


        [Fact]
        public async Task GetUserListTest()
        {
            //Act
            var result = await _handler.Handle(new GetUserListRequest(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<List<UserDto>>();
            result.Count.ShouldBe(3);
        }
    }
}

