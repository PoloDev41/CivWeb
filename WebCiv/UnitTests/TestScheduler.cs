using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebCiv.Areas.ScheduleService;

namespace UnitTests
{
    class TestScheduler
    {
        [Test]
        public void TestAddNotCyclicTask()
        {
            SchedulerHostedService shs = new SchedulerHostedService();
            shs.StartAsync(new CancellationToken());

            Semaphore mut = new Semaphore(0, 1);
            ScheduledTaskBuffer.AddScheduledTask(new ScheduledTask(() => mut.Release(), TimeSpan.FromSeconds(1)));

            try
            {
                if (mut.WaitOne(3000) == false)
                    Assert.Fail("The task was not executed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

            if (mut.WaitOne(3000) == true)
                Assert.Fail("The task was executed, but it must not.");
        }

        [Test]
        public void TestAddCyclicTask()
        {
            SchedulerHostedService shs = new SchedulerHostedService();
            shs.StartAsync(new CancellationToken());

            Semaphore mut = new Semaphore(0, 3);
            ScheduledTaskBuffer.AddScheduledTask(new ScheduledTask(() => mut.Release(), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(0)));

            try
            {
                if (mut.WaitOne(2500) == false)
                    Assert.Fail("The task was not executed");
                if (mut.WaitOne(3000) == false)
                    Assert.Fail("The task was not executed a second time");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                shs.StopAsync(new CancellationToken());
            }
            if (mut.WaitOne(3000) == true || mut.WaitOne(3000) == true) //the scheduler is stop so, no task should be executed
                Assert.Fail("the scheduler still executes tasks");
        }
    }
}
