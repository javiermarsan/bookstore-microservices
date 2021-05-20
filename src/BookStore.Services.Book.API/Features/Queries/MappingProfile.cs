using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Services.Book.API.Infrastructure.Model;

namespace BookStore.Services.Book.API.Features.Queries
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, BookDto>();
        }
    }
}
