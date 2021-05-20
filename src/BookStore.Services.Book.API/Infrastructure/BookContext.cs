using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Services.Book.API.Infrastructure.Model;

namespace BookStore.Services.Book.API.Infrastructure
{
    public class BookContext : DbContext
    {
        public BookContext() { }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public virtual DbSet<BookEntity> Book { get; set; }

    }
}
