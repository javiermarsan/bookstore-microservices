using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Services.Basket.API.Infrastructure.Model;

namespace BookStore.Services.Basket.API.Infrastructure
{
    public class BasketContext : DbContext
    {
        public BasketContext() { }

        public BasketContext(DbContextOptions<BasketContext> options) : base(options) { }

        public virtual DbSet<BasketEntity> Basket { get; set; }
        public virtual DbSet<BasketItemEntity> BasketItem { get; set; }
    }
}
