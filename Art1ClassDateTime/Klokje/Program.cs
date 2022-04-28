using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klokje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToString("T"));
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
