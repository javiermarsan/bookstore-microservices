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
    public class GetDetailQueryHandler : IRequestHandler<GetDetailQuery, BookDto>
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public GetDetailQueryHandler(BookContext contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetDetailQuery request, CancellationToken cancellationToken)
        {
            var libro = await _context.Book.Where(x => x.BookId == request.BookId).FirstOrDefaultAsync();
            if (libro == null)
                throw new Exception("Book not found");

            var libroDto = _mapper.Map<BookEntity, BookDto>(libro);
            return libroDto;
        }
    }
}
