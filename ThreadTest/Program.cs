using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("step 1 ...");
            Action<int,int> writeText = (i,j) =>
            {
                Thread.Sleep(j);
                Console.WriteLine(i + " : " + DateTime.Now.TimeOfDay);
            };

            writeText(1, 3000);
            writeText(2, 1500);
            writeText(3, 1500);

            Console.WriteLine("press enter");
            Console.ReadLine();
            Console.WriteLine("step 2 ...");

            var t1 = new Thread(() => writeText(4, 3000));
            var t2 = new Thread(() => writeText(5, 1500));
            var t3 = new Thread(() => writeText(6, 1500));
            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("press enter to close");
            Console.ReadLine();
        }
    }
}
