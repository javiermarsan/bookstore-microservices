using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Services.Book.API.Infrastructure;
using BookStore.Services.Book.API.Infrastructure.Model;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.Book.API.Features.Commands
{
    public class DeleteCommand : IRequest<bool>
    {
        public Guid BookId { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
        {
            private readonly BookContext _context;

            public DeleteCommandHandler(BookContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                BookEntity entity = await _context.Book.Where(a => a.BookId == request.BookId).FirstOrDefaultAsync();
                if (entity == null)
                    return false;

                _context.Book.Remove(entity);

                int value = await _context.SaveChangesAsync();
                if (value > 0)
                    return true;

                throw new Exception("Failed to delete the book");
            }
        }
    }
}
