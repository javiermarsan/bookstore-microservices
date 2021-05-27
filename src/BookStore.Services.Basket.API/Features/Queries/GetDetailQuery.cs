using BookStore.Services.Basket.API.Infrastructure;
using BookStore.Services.Basket.API.Infrastructure.Model;
using BookStore.Services.Basket.API.Remote.Interface;
using BookStore.Services.Basket.API.Remote.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Features.Queries
{
    public class GetDetailQuery : IRequest<BasketDto>
    {
        public Guid? BasketId { get; set; }

        public class GetDetailQueryHandler : IRequestHandler<GetDetailQuery, BasketDto>
        {
            private readonly BasketContext _context;
            private readonly IBookService _bookService;

            public GetDetailQueryHandler(BasketContext context, IBookService bookService)
            {
                _context = context;
                _bookService = bookService;
            }

            public async Task<BasketDto> Handle(GetDetailQuery request, CancellationToken cancellationToken)
            {
                List<BasketItemDto> listDto = new List<BasketItemDto>();
                BasketEntity entity = await _context.Basket.FirstOrDefaultAsync(x => x.BasketId == request.BasketId);
                List<BasketItemEntity> entityItems = await _context.BasketItem.Where(x => x.BasketId == request.BasketId).ToListAsync();

                foreach (BasketItemEntity item in entityItems)
                {
                    var response = await _bookService.GetBook(item.ProductId);
                    if (response.result)
                    {
                        BookRemote book = response.Book;
                        BasketItemDto itemDto = new BasketItemDto
                        {
                            BasketItemId = item.Id,
                            BookId = book.BookId,
                            BookTitle = book.Title,
                            PublicationDate = book.PublicationDate,
                            AuthorId = book.AuthorId
                        };
                        listDto.Add(itemDto);
                    }
                }

                BasketDto basketDto = new BasketDto
                {
                    BasketId = entity.BasketId,
                    CreationDate = entity.CreationDate,
                    Items = listDto
                };

                return basketDto;
            }
        }
    }
}
