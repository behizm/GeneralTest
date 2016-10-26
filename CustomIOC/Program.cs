using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomIOC.Interfaces;
using CustomIOC.Models;
using CustomIOC.Services;

namespace CustomIOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Hub.Instance.StudentService.Start();
            Hub.Instance.StudentService.WriteInfo(2);
            Console.WriteLine(Hub.Instance.StudentService.GetHashCode());
            Console.ReadLine();

            Hub.Instance.StudentService.WriteInfo(2);
            Console.WriteLine(Hub.Instance.StudentService.GetHashCode());
            Console.ReadLine();

            Hub.DisposeInstance();

            Hub.Instance.StudentService.WriteInfo(2);
            Console.WriteLine(Hub.Instance.StudentService.GetHashCode());
            Console.ReadLine();

            var hub = new Hub();
            hub.StudentService.WriteInfo(2);
            Console.WriteLine(hub.StudentService.GetHashCode());
            hub.StudentService.End();
            Console.ReadLine();
        }
    }
}
