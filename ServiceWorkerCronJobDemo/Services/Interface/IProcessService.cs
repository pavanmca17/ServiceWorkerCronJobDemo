using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceWorkerCronJobDemo.Services.Interface
{
    public interface IProcessService
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
