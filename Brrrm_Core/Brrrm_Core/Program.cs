using System;
using System.IO;
using System.Reflection;

namespace Brrrm_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Core c = new Core();
            c.LoadConfig("666");
            Console.ReadKey();
        }

    }
}
