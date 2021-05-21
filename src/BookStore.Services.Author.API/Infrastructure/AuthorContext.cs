using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Services.Author.API.Infrastructure.Model;

namespace BookStore.Services.Author.API.Infrastructure
{
    public class AuthorContext : DbContext
    {
        public AuthorContext() { }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        public virtual DbSet<AuthorEntity> Author { get; set; }

    }
}
