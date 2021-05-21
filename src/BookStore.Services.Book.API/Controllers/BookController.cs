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
        public async Task<ActionResult<Guid>> CreateBook(CreateCommand data)
        {
            Guid newId = await _mediator.Send(data);
            return newId;
        }

        [HttpPut]
        //[HttpPost]
        //[Route("update")]
        public async Task<ActionResult> UpdateBook(UpdateCommand data)
        {
            bool found = await _mediator.Send(data);
            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        //[HttpPost]
        //[Route("delete")]
        public async Task<ActionResult> DeleteBook(DeleteCommand data)
        {
            bool found = await _mediator.Send(data);
            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            return await _mediator.Send(new GetListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            return await _mediator.Send(new GetDetailQuery { BookId = id });
        }
    }
}
