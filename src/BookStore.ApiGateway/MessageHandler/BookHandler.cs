using BookStore.ApiGateway.Remote;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.ApiGateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        private readonly ILogger<BookHandler> _logger;
        private readonly IAuthorService _authorService;

        public BookHandler(ILogger<BookHandler> logger, IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Stopwatch time = Stopwatch.StartNew();
            _logger.LogInformation("Start request");

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookRemote>(content, options);
                var responseAuthor = await _authorService.GetAuthor(result.AuthorId);
                if (responseAuthor.result)
                {
                    var objAuthor = responseAuthor.author;
                    result.AuthorData = objAuthor;
                    var resultadoStr = JsonSerializer.Serialize(result);
                    response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
                }
            }

            _logger.LogInformation($"Process execution time {time.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
