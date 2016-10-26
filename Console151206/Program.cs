using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Console151206
{
    class Program
    {
        static void Main()
        {
            var runTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 28, 0);
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            var job = JobBuilder.Create<FirstJob>().WithIdentity("job1", "group1").Build();
            var trigger =
                TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartAt(runTime)
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(15).RepeatForever())
                    .Build();
            scheduler.ScheduleJob(job, trigger);
            Console.ReadLine();
            scheduler.Shutdown();
        }
    }
}
