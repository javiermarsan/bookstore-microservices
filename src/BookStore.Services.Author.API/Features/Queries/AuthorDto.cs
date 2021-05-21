using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Author.API.Features.Queries
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }

        public string Name { get; set; }
    }
}
