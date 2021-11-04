using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceWorkerCronJobDemo.Services.Interface;
using ServiceWorkerCronJobDemo.Test;

namespace ServiceWorkerCronJobDemo.Services
{
    public class ProcessService : IProcessService
    {
        private readonly ILogger<ProcessService> _logger;

        public ProcessService(ILogger<ProcessService> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
             Trail trail = new Trail();

            _logger.LogInformation("ProcessService is working.");
             await Task.Delay(1000 * 20, cancellationToken);
        }
    }
}
