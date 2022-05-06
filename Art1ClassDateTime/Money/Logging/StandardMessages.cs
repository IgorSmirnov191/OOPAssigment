using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class StandardMessages
    {
        public static void DisplayInputMessageAccountName()
        {
            Console.WriteLine("Geef een rekeningnaam: ");
        }

        public static void DisplayInputMessageAccountNumber()
        {
            Console.WriteLine("Geef een rekeningnummer: ");
        }

        public static void DisplayTransactionStartAccountInfo(string fieldName, string fieldNumber, double fieldSaldo)
        {
            Console.WriteLine($"Transaction benaderd voor rekening : {fieldName} {fieldNumber} Saldo: e{fieldSaldo}");
 
        }
        public static void DisplayTransactionSuccessAccountInfo(string fieldName, string fieldNumber, double fieldSaldo)
        {
            Console.WriteLine($"Transaction endigd. Success. : {fieldName} {fieldNumber} Saldo: e{fieldSaldo}");

        }
        public static void DisplayTransactionAddMoneyInfo(double amount)
        {
            Console.WriteLine($"In transaction : Voeg Geld Toe. e{amount}");
        }

        public static void DisplayTransactionTakeMoneyOffInfo(double amount)
        {
            Console.WriteLine($"In transaction : Haal Geld Af. e{amount}");
        }

        public static void DisplayTransactionCalculateInterestInfo(double amount)
        {
            Console.WriteLine($"In transaction : Rente berekeren. e{amount}");
        }
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
