using AutoMapper;
using BookStore.Services.Author.API.Infrastructure;
using BookStore.Services.Author.API.Infrastructure.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Author.API.Features.Queries
{
    public class GetDetailQuery : IRequest<AuthorDto>
    {
        public Guid? AuthorId { get; set; }

        public class GetDetailQueryHandler : IRequestHandler<GetDetailQuery, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public GetDetailQueryHandler(AuthorContext contexto, IMapper mapper)
            {
                _context = contexto;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(GetDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Author.Where(x => x.AuthorId == request.AuthorId).FirstOrDefaultAsync();
                if (entity == null)
                    throw new Exception("Author not found");

                var dto = _mapper.Map<AuthorEntity, AuthorDto>(entity);
                return dto;
            }
        }
    }
}
