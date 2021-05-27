using BookStore.Services.Basket.API.Remote.Interface;
using BookStore.Services.Basket.API.Remote.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Remote.Service
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("BooksHttp");
                var response = await cliente.GetAsync($"api/Book/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    BookRemote obj = JsonSerializer.Deserialize<BookRemote>(content, options);
                    return (true, obj, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
