using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SequentialGuid
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            var fileBytes = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"\sitelogo.png");
            var base64 = Convert.ToBase64String(fileBytes);
            Console.WriteLine(base64);
            Console.WriteLine("file readed.");
            var formbase64 = Convert.FromBase64String(base64);
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"\1.jpg", formbase64);
            Console.WriteLine("file saved.");
            Console.ReadLine();
        }

        static void Main2()
        {
            Action action = () =>
            {
                var st = string.Empty;
                while (string.IsNullOrEmpty(st))
                {
                    Console.Write("text : ");
                    st = Console.ReadLine();
                }

                var byteSt = Encoding.UTF32.GetBytes(st);
                //byteSt.ToList().ForEach(x => Console.WriteLine(x + " : " + Convert.ToInt32(x) + " : " + x.ToString("x2")));

                var base64 = Convert.ToBase64String(byteSt);
                Console.WriteLine(base64);
                var formbase64 = Convert.FromBase64String(base64);
                //formbase64.ToList().ForEach(x => Console.WriteLine(x + " : " + Convert.ToInt32(x) + " : " + x.ToString("x2")));
                Console.WriteLine(Encoding.UTF32.GetString(formbase64));
            };

            string q;
            do
            {
                action();
                Console.Write("Again? (y or n)");
                q = Console.ReadLine();
            } while (q != "n");
        }

        static void Main1()
        {
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine();

            Console.WriteLine(GuidComb.GenerateComb());
            Console.WriteLine(GuidComb.GenerateComb());
            Console.WriteLine();

            var guidByte = Guid.NewGuid().ToByteArray();
            guidByte.ToList().ForEach(x => Console.WriteLine(x + " : " + Convert.ToInt32(x) + " : " + x.ToString("x2")));
            Console.WriteLine(BitConverter.ToUInt64(guidByte, 0));
            Console.WriteLine(BitConverter.ToString(guidByte, 0));
            Console.WriteLine(Convert.ToBase64String(guidByte));
            Console.WriteLine(new Guid(guidByte));
            Console.ReadLine();
        }
    }
}
