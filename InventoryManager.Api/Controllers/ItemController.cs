using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Application.Features.Items.Requests.Queries;
using InventoryManager.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> Get()
        {
            var response = await _mediator.Send(new GetItemListRequest());
            return Ok(response);
        }

        //GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetItemDetailRequest { Id = id });
            return Ok(response);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateItemDto leaveType)
        {
            var command = new CreateItemCommand { ItemDto = leaveType };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // DELETE: api/Item/test
        [HttpDelete("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            var command = new DeleteItemByNameCommand { Name = name };

            try
            {
                var response = await _mediator.Send(command);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
