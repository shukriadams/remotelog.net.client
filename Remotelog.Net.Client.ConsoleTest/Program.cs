using System;

namespace Remotelog.Net.Client.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Write("testing log from console app");
            Console.WriteLine("Wrote to log. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
