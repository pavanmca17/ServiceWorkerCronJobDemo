using System;
using ServiceWorkerCronJobDemo.Services.Interface;

namespace ServiceWorkerCronJobDemo.Services
{
    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
