using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.ApiGateway.Remote
{
    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IHttpClientFactory httpClient, ILogger<AuthorService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, AuthorRemote author, string errorMessage)> GetAuthor(Guid AuthorId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("AuthorHttp");
                var response = await cliente.GetAsync($"api/Author/{AuthorId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    AuthorRemote obj = JsonSerializer.Deserialize<AuthorRemote>(content, options);
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
