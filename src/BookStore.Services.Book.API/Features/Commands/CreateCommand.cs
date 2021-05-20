using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Features.Commands
{
    public class CreateCommand : IRequest
    {
        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid? BookAuthorId { get; set; }
    }
}
