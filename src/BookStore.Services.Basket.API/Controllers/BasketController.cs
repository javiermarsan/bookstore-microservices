using BookStore.Services.Basket.API.Features.Commands;
using BookStore.Services.Basket.API.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBasket(CreateCommand data)
        {
            Guid newId = await _mediator.Send(data);
            return newId;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasketById(Guid id)
        {
            return await _mediator.Send(new GetDetailQuery { BasketId = id });
        }
    }
}
