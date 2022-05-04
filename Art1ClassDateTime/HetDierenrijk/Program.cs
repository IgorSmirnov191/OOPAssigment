using System;
using System.Collections.Generic;

namespace HetDierenrijk
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();

            list.Add(new Animal());
            list.Add(new Reptile());
            list.Add(new Mammal());
            list.Add(new Bird());

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
                item.ToonInfo();
            }
        }
    }
}