using System;

namespace Klokje
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToString("T"));
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}