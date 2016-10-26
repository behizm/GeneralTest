using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Console151206
{
    public class FirstJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Run first job at " + DateTime.Now);
        }
    }
}
