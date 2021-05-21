using BookStore.Services.Author.API.Infrastructure;
using BookStore.Services.Author.API.Infrastructure.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Author.API.Features.Commands
{
    public class CreateCommand : IRequest<Guid>
    {
        public string Name { get; set; }


        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            }
        }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, Guid>
        {
            private readonly AuthorContext _context;

            public CreateCommandHandler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                AuthorEntity entity = new AuthorEntity
                {
                    Name = request.Name
                };

                _context.Author.Add(entity);

                int value = await _context.SaveChangesAsync();
                if (value > 0)
                    return entity.AuthorId;

                throw new Exception("Failed to save the author");
            }
        }
    }
}
