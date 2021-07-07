using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCheckService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient UserClient = new()
        {
            BaseAddress = new("https://futuremeuserapi.azurewebsites.net")
        };
        private readonly HttpClient LetterClient = new()
        {
            BaseAddress = new("https://futuremebackenddatabase.azurewebsites.net")
        };
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var task1 = UserClient.GetFromJsonAsync<bool>("api/Check/is-running");
                    var task2 = LetterClient.GetFromJsonAsync<bool>("api/Check/is-running");
                    await Task.WhenAll(task1, task2);
                    _logger.LogInformation($"The apis is on at {DateTimeOffset.Now}");
                }
                catch(Exception e)
                {
                    _logger.LogError(e.Message);
                }
                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}
