using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Application.DTOs.ItemEvents;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.Exceptions;
using InventoryManager.Application.Features.ItemEvents.Requests.Queries;
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
    [Authorize]
    public class ItemEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<List<ItemEventDto>>> Get()
        {
            var response = await _mediator.Send(new GetItemEventListRequest());
            return Ok(response);
        }
    }
}
