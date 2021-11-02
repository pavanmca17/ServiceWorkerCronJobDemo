using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceWorkerCronJobDemo.Services.Interface;


namespace ServiceWorkerCronJobDemo.Services
{
    public class ProcessJobService : CronJobService
    {
        private readonly ILogger<ProcessJobService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ProcessJobService(IScheduleConfig<ProcessJobService> config, ILogger<ProcessJobService> logger, 
               IServiceProvider serviceProvider)
            : base(config.CronExpression, config.TimeZoneInfo, logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ProcessJobService started");
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ProcessJobService is working.");
            using var scope = _serviceProvider.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IProcessService>();
            await svc.DoWork(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 2 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
