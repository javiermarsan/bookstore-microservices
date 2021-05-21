using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Services.Author.API.Infrastructure.Model;

namespace BookStore.Services.Author.API.Features.Queries
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>();
        }
    }
}
