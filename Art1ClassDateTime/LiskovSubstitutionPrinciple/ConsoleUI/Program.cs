using DemoLibrary;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IManager accountingVP = new CEO();
            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            Employee emp = new Manager();
            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            emp.AssingManager(accountingVP);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{emp.FirstName}'s salary is e{emp.Salary} /hour.");
            Console.ReadLine();
        }
    }
}