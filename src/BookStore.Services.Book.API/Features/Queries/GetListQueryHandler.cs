using AutoMapper;
using BookStore.Services.Book.API.Infrastructure;
using BookStore.Services.Book.API.Infrastructure.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Features.Queries
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<BookDto>>
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public GetListQueryHandler(BookContext contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            List<BookEntity> list = await _context.Book.ToListAsync();
            List<BookDto> listDto = _mapper.Map<List<BookEntity>, List<BookDto>>(list);
            return listDto;
        }
    }
}
