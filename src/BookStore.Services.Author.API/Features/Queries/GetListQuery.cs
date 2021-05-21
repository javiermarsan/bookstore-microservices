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
    public class GetListQuery : IRequest<List<AuthorDto>>
    {
        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public GetListQueryHandler(AuthorContext contexto, IMapper mapper)
            {
                _context = contexto;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<AuthorEntity> list = await _context.Author.ToListAsync();
                List<AuthorDto> listDto = _mapper.Map<List<AuthorEntity>, List<AuthorDto>>(list);
                return listDto;
            }
        }
    }
}
