using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class StandardMessages
    {
        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"You did not give us a valid {fieldName} !");
        }

        public static void AccountLockingError()
        {

            Console.WriteLine("Account is locked.");
        }
        public static void TransactionFout()
        {
            Console.Write("Not validated. Press enter to close...");
            Console.ReadLine();
        }
        
        public static void EndApplication()
        {
            Console.Write("Press enter to close...");
            Console.ReadLine();
        }

    }
}
