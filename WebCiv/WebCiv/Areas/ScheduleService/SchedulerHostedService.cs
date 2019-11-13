using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebCiv.Areas.ScheduleService
{
    /// <summary>
    /// class to schedule any tasks
    /// </summary>
    public class SchedulerHostedService : IHostedService
    {
        /// <summary>
        /// start service
        /// </summary>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>completed task</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Stop the service
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>completed task</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
