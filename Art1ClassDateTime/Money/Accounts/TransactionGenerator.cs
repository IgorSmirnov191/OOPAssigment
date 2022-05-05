using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class TransactionGenerator
    {
        public static void TransactionStart(IRekening rekening)
        {
            Console.WriteLine($"Transaction benaderd voor rekening : {rekening.Name} {rekening.Number} Saldo: e{rekening.Saldo}");
        }

        public static void TransactionVoegGeldToe(IRekening rekening,double amount)
        {
            Console.WriteLine($"In transaction : Voeg Geld Toe. e{amount}");
            rekening.VoegGeldToe(amount);
        }

        public static void TransactionHaalGeldAf(IRekening rekening, double amount)
        {
            Console.WriteLine($"In transaction : Haal Geld Af. e{amount}");
            rekening.HaalGeldAf(amount);
        }
        public static double TransactionBerekerenRente(IRekening rekening)
        {
            double amount = rekening.BerekenRente();
            Console.WriteLine($"In transaction : Rente berekeren. e{amount}");
            return amount;
        }

        public static void TransactionEnd(IRekening rekening)
        {
            Console.WriteLine($"Transaction endigd. Success. : {rekening.Name} {rekening.Number} Saldo: e{rekening.Saldo}");
        }
    }
}
