using BookStore.Services.Book.API.Infrastructure;
using BookStore.Services.Book.API.Infrastructure.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Features.Commands
{
    public class CreateCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid BookAuthorId { get; set; }

        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
                RuleFor(x => x.BookAuthorId).NotEmpty();
            }
        }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, Guid>
        {
            private readonly BookContext _context;

            public CreateCommandHandler(BookContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                BookEntity book = new BookEntity
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    BookAuthorId = request.BookAuthorId
                };

                _context.Book.Add(book);

                int value = await _context.SaveChangesAsync();
                if (value > 0)
                    return book.BookId;

                throw new Exception("Failed to save the book");
            }
        }
    }
}
