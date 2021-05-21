using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Services.Author.API.Infrastructure;
using BookStore.Services.Author.API.Infrastructure.Model;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.Author.API.Features.Commands
{
    public class DeleteCommand : IRequest<bool>
    {
        public Guid AuthorId { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
        {
            private readonly AuthorContext _context;

            public DeleteCommandHandler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                AuthorEntity entity = await _context.Author.Where(a => a.AuthorId == request.AuthorId).FirstOrDefaultAsync();
                if (entity == null)
                    return false;

                _context.Author.Remove(entity);

                int value = await _context.SaveChangesAsync();
                if (value > 0)
                    return true;

                throw new Exception("Failed to delete the author");
            }
        }
    }
}
