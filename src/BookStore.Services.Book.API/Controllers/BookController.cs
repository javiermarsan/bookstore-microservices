using BookStore.Services.Book.API.Features.Commands;
using BookStore.Services.Book.API.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateCommand data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetList()
        {
            return await _mediator.Send(new GetListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetDetail(Guid id)
        {
            return await _mediator.Send(new GetDetailQuery { BookId = id });
        }
    }
}
