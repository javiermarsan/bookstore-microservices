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
    public class UpdateCommand : IRequest<bool>
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid AuthorId { get; set; }

        public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
        {
            public UpdateCommandValidator()
            {
                RuleFor(x => x.BookId).NotEmpty();
                RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
                RuleFor(x => x.AuthorId).NotEmpty();
            }
        }

        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
        {
            private readonly BookContext _context;

            public UpdateCommandHandler(BookContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                BookEntity entity = await _context.Book.Where(a => a.BookId == request.BookId).FirstOrDefaultAsync();
                if (entity == null)
                    return false;

                entity.Title = request.Title;
                entity.PublicationDate = request.PublicationDate;
                entity.AuthorId = request.AuthorId;

                await _context.SaveChangesAsync();
                
                return true;
            }
        }
    }
}
