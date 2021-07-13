using Fero.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fero
{
    public class Worker : BackgroundService
    {
        private static readonly int IDLE_MINUTES = 5;
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }
        public IServiceProvider Services { get; }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = Services.CreateScope())
                {
                    var modelService = scope.ServiceProvider
                            .GetRequiredService<IModelService>();
                    await modelService.ScanCasting();
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(IDLE_MINUTES * 60 * 1000, stoppingToken);
            }
        }
    }
}
