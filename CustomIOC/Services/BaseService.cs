using System;
using CustomIOC.Interfaces;

namespace CustomIOC.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public void Start()
        {
            var type = typeof(T);
            Console.WriteLine($"This is start ({type.Name}) ...");
        }

        public void End()
        {
            Console.WriteLine("... This is end");
        }
    }
}