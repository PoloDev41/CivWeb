using System;

namespace WebCiv.Areas.ScheduleService
{
    /// <summary>
    /// class with an action to execute at specific time
    /// </summary>
    public class ScheduledTask
    {
        /// <summary>
        /// Scheduled task
        /// </summary>
        public Action Task { get; private set; }

        /// <summary>
        /// time to start the scheduled task
        /// </summary>
        public TimeSpan StartTiming { get; private set; }

        /// <summary>
        /// Delay between 2 execution, if null, the task will be execute only one time
        /// </summary>
        public TimeSpan? Schedule { get; private set; }

        /// <summary>
        /// create a new scheduled task with no cyclic execution
        /// </summary>
        /// <param name="task">task to execute</param>
        /// <param name="delay">delay before execute the task</param>
        public ScheduledTask(Action task, TimeSpan delay) : this(task, null, delay)
        {
            
        }

        /// <summary>
        /// Create a new scheduled task with cyclic execution
        /// </summary>
        /// <param name="task">task to execute</param>
        /// <param name="schedule">delay between 2 executiions of the task</param>
        /// <param name="delay">delay before executing the 1st task</param>
        public ScheduledTask(Action task, TimeSpan? schedule, TimeSpan delay)
        {
            StartTiming = delay;
            Schedule = schedule;
            Task = task;
        }
    }
}