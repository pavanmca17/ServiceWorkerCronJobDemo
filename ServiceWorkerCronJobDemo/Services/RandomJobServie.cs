using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceWorkerCronJobDemo.Services.Interface;

namespace ServiceWorkerCronJobDemo.Services
{
    public class RandomJobServie : CronJobService
    {
        private readonly ILogger<RandomJobServie> _logger;

        public RandomJobServie(IScheduleConfig<RandomJobServie> config,
            ILogger<RandomJobServie> logger)
            : base(config.CronExpression, config.TimeZoneInfo,logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("RandomJobServie started");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} RandomJobServie is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("RandomJobServie is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
