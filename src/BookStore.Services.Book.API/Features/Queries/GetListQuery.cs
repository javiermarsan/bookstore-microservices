using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Features.Queries
{
    public class GetListQuery : IRequest<List<BookDto>>
    {
    }

}
