using BookStore.Services.Author.API.Features.Commands;
using BookStore.Services.Author.API.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Author.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAuthor(CreateCommand data)
        {
            Guid newId = await _mediator.Send(data);
            return newId;
        }

        [HttpPut]
        //[HttpPost]
        //[Route("update")]
        public async Task<ActionResult> UpdateAuthor(UpdateCommand data)
        {
            bool found = await _mediator.Send(data);
            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        //[HttpPost]
        //[Route("delete")]
        public async Task<ActionResult> DeleteAuthor(DeleteCommand data)
        {
            bool found = await _mediator.Send(data);
            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new GetListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        {
            return await _mediator.Send(new GetDetailQuery { AuthorId = id });
        }
    }
}
