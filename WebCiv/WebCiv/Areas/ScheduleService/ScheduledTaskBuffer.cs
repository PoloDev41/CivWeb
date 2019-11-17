using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Areas.ScheduleService
{
    /// <summary>
    /// class to buffer scheduled tasks
    /// </summary>
    public static class ScheduledTaskBuffer
    {
        /// <summary>
        /// scheduler service
        /// </summary>
        private static SchedulerHostedService _scheduler;

        /// <summary>
        /// initialize the class
        /// </summary>
        /// <param name="schedulerService">used service to schedule task</param>
        public static void Initialize(SchedulerHostedService schedulerService)
        {
            _scheduler = schedulerService;
        }

        /// <summary>
        /// add a new schelued task
        /// </summary>
        /// <param name="scheduledTask">scheduled task to add</param>
        public static decimal AddScheduledTask(ScheduledTask scheduledTask)
        {
            return _scheduler.AddNewTask(scheduledTask);
        }
    }
}
