using System;

namespace ConsoleUI
{
    public class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to my apps");
        }

        public static void EndApplication()
        {
            Console.Write("Press enter to close...");
            Console.ReadLine();
        }

        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"You did not give us a valid {fieldName} !");
        }
    }
}