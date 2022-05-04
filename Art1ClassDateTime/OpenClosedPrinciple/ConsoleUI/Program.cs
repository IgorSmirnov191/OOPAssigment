using OCPLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //List<PersonModel> applicants = new List<PersonModel> {
            //    new PersonModel{FirstName = "Tim", LastName = "Corey"},
            //     new PersonModel{FirstName = "Sue", LastName = "Storm"},
            //      new PersonModel{FirstName = "Nancy", LastName = "Roman"}
            //};

            //List<EmployeeModel> employees = new List<EmployeeModel>();
            //Accounts accountProcessor = new Accounts();

            //foreach(var person in applicants)
            //{
            //    employees.Add(accountProcessor.Create(person));
            //}

            //foreach (var emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress}");
            //}
            //Console.ReadLine();

            List<PersonModel> applicants = new List<PersonModel> {
                new PersonModel{FirstName = "Tim", LastName = "Corey"},
                 new PersonModel{FirstName = "Sue", LastName = "Storm", TypeOfEmployee = EmployeeType.Manager},
                  new PersonModel{FirstName = "Nancy", LastName = "Roman",TypeOfEmployee = EmployeeType.Executive}
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            Accounts accountProcessor = new Accounts();

            foreach (var person in applicants)
            {
                employees.Add(accountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: {emp.IsManager} IsExecutive {emp.IsExecutive}");
            }
            Console.ReadLine();
        }
    }
}