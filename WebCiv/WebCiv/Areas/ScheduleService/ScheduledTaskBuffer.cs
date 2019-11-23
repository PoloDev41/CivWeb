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

        /// <summary>
        /// return the delay until next midnight
        /// </summary>
        /// <returns>delay until next midnight</returns>
        public static TimeSpan GetDelayToMidnight()
        {
            DateTime now = DateTime.Now;
            DateTime tomorrow = now.AddDays(1);
            DateTime midnight = new DateTime(tomorrow.Year, tomorrow.Month,
                                    tomorrow.Day, 0, 0, 0);
            return now - midnight;
        }
    }
}
