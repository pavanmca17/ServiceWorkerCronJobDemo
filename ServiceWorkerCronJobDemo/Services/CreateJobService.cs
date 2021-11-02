using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceWorkerCronJobDemo.Services.Interface;

namespace ServiceWorkerCronJobDemo.Services
{
    public class CreateJobService : CronJobService
    {
        private readonly ILogger<CreateJobService> _logger;

        public CreateJobService(IScheduleConfig<CreateJobService> config, ILogger<CreateJobService> logger)
            : base(config.CronExpression, config.TimeZoneInfo, logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateJobService Started");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateJobService is working");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateJobService is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
