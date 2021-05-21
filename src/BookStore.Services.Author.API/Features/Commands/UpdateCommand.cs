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
    public class UpdateCommand : IRequest<bool>
    {
        public Guid AuthorId { get; set; }

        public string Name { get; set; }

        public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
        {
            public UpdateCommandValidator()
            {
                RuleFor(x => x.AuthorId).NotEmpty();
                RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            }
        }

        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
        {
            private readonly AuthorContext _context;

            public UpdateCommandHandler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                AuthorEntity entity = await _context.Author.Where(a => a.AuthorId == request.AuthorId).FirstOrDefaultAsync();
                if (entity == null)
                    return false;

                entity.Name = request.Name;

                await _context.SaveChangesAsync();
                
                return true;
            }
        }
    }
}
