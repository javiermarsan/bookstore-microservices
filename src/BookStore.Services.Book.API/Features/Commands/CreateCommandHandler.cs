using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Services.Book.API.Infrastructure;
using BookStore.Services.Book.API.Infrastructure.Model;
using MediatR;

namespace BookStore.Services.Book.API.Features.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly BookContext _context;

        public CreateCommandHandler(BookContext contexto)
        {
            _context = contexto;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            BookEntity book = new BookEntity
            {
                Title = request.Title,
                PublicationDate = request.PublicationDate,
                BookAuthorId = request.BookAuthorId.Value
            };

            _context.Book.Add(book);

            var value = await _context.SaveChangesAsync();
            if (value > 0)
                return Unit.Value;

            throw new Exception("Failed to save the book");
        }
    }
}
