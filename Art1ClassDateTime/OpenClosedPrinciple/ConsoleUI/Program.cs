using OCPLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
                List<IApplicantModel> applicants = new List<IApplicantModel> {
                new PersonModel{FirstName = "Tim", LastName = "Corey"},
                new PersonModel{FirstName = "Sue", LastName = "Storm"},
                new ExecutiveModel{FirstName = "Nancy", LastName = "Roman"},
                new TechnicianModel{FirstName ="Jeff", LastName = "Wainberg"}
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();


            foreach (var person in applicants)
            {
                employees.Add(person.AccountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: {emp.IsManager} IsExecutive {emp.IsExecutive}");
            }
            Console.ReadLine();
        }
    }
}