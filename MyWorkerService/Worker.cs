using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Run at: {time}", DateTimeOffset.Now);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Stop at: {time}", DateTimeOffset.Now);

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if(GetResponse())
                    _logger.LogInformation("Response is OK: {time}", DateTimeOffset.Now);
                else
                {
                    _logger.LogInformation("No Response at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(3000, stoppingToken);
            }
        }

        public bool GetResponse()
        {
            return true;  // yOu can write login here..
        }
    }
}
