using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ApiGateway.Remote
{
    public interface IAuthorService
    {
        Task<(bool result, AuthorRemote author, string errorMessage)> GetAuthor(Guid AuthorId);

    }
}
