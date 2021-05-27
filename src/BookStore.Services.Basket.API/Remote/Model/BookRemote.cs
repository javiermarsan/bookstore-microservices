using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Remote.Model
{
    public class BookRemote
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid AuthorId { get; set; }
    }
}
