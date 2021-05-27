using BookStore.Services.Basket.API.Remote.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Remote.Interface
{
    public interface IBookService
    {
        Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(Guid BookId);

    }
}
