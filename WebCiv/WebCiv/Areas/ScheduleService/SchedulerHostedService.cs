using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WebCiv.DAL;
using WebCiv.Engine;
using static WebCiv.Areas.ScheduleService.ScheduledTask;

namespace WebCiv.Areas.ScheduleService
{
    /// <summary>
    /// class to schedule any tasks
    /// </summary>
    public class SchedulerHostedService : IHostedService
    {
        /// <summary>
        /// ratio to accelerate the scheduler service
        /// </summary>
        private int AcceleratorRate = 1;

        /// <summary>
        /// generate of id for identify tasks
        /// </summary>
        private decimal _idGenerator { get; set; }

        /// <summary>
        /// buffer to store tasks before add them in the pending task list
        /// </summary>
        private ConcurrentQueue<ScheduledTask> _taskBuffer { get; set; }

        /// <summary>
        /// task which will execute on the next timer event
        /// </summary>
        private List<TimingTask> _pendingTasks { get; set; }

        /// <summary>
        /// timer
        /// </summary>
        private System.Timers.Timer _timer { get; set; }

        /// <summary>
        /// service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// create a scheduler hosted service
        /// </summary>
        /// <param name="serviceProvider">service provider</param>
        public SchedulerHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// start service
        /// </summary>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>completed task</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _idGenerator = 0;
            _taskBuffer = new ConcurrentQueue<ScheduledTask>();
            _pendingTasks = new List<TimingTask>();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            ScheduledTaskBuffer.Initialize(this);

            ScheduledTaskBuffer.AddScheduledTask(new ScheduledTask(Population.RoutineGrowAllPopulations, TimeSpan.FromDays(1), ScheduledTaskBuffer.GetDelayToMidnight()));

            return Task.CompletedTask;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            int tries = _taskBuffer.Count;
            for (int i = 0; i < tries; i++)
            {
                if (_taskBuffer.TryDequeue(out ScheduledTask result))
                {
                    this._pendingTasks.Add(new TimingTask(result));
                }
            }
            IServiceScope scope = null; 
            ApplicationDbContext myDbContext = null; 

            if(_serviceProvider != null)
            {
                scope = _serviceProvider.CreateScope();
                myDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            }

            for (int i = this._pendingTasks.Count - 1; i >= 0; i--)
            {
                var task = this._pendingTasks[i];
                if (task.RemainingTime.TotalSeconds <= 1)
                {
                    task.Task.Task(myDbContext);
                    if (task.Task.Schedule != null)
                    {
                        task.RemainingTime = task.Task.Schedule.Value;
                    }
                    else
                    {
                        this._pendingTasks.RemoveAt(i);
                    }
                }
                else
                {
                    task.RemainingTime = task.RemainingTime.Subtract(TimeSpan.FromSeconds(1 * AcceleratorRate));
                }
            }
            try
            {
                _timer.Start();
            }
            catch (Exception)
            {
                //do nothing, the timer should be disposed
            }            
        }

        /// <summary>
        /// Stop the service
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>completed task</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._timer.Stop();
            this._timer.Dispose();
            return Task.CompletedTask;
        }

        /// <summary>
        /// add the task to the scheduler
        /// </summary>
        /// <param name="scheduledTask">scheduled task</param>
        /// <returns>id of the task</returns>
        public decimal AddNewTask(ScheduledTask scheduledTask)
        {
            decimal id = _idGenerator;
            this._taskBuffer.Enqueue(scheduledTask);
            _idGenerator++;
            return id;
        }
    }

    /// <summary>
    /// class to add a timing on a scheduled task
    /// </summary>
    class TimingTask
    {
        /// <summary>
        /// scheduled task to execute
        /// </summary>
        public ScheduledTask Task { get; set; }

        /// <summary>
        /// remaining time before execute the task
        /// </summary>
        public TimeSpan RemainingTime { get; set; }

        /// <summary>
        /// create a new timing task
        /// </summary>
        /// <param name="task">task to scheduled</param>
        public TimingTask(ScheduledTask task)
        {
            RemainingTime = task.StartTiming;
            Task = task;
        }
    }
}
