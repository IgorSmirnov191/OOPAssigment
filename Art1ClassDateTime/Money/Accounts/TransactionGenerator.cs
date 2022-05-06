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
            StandardMessages.DisplayTransactionStartAccountInfo(rekening.Name, rekening.Number, rekening.Saldo);
        }

        public static void TransactionVoegGeldToe(IRekening rekening,double amount)
        {
            StandardMessages.DisplayTransactionAddMoneyInfo(amount);
            rekening.VoegGeldToe(amount);
        }

        public static void TransactionHaalGeldAf(IRekening rekening, double amount)
        {
           StandardMessages.DisplayTransactionTakeMoneyOffInfo(amount);
           rekening.HaalGeldAf(amount);
        }
        public static double TransactionBerekerenRente(IRekening rekening)
        {
            double amount = rekening.BerekenRente();
            StandardMessages.DisplayTransactionCalculateInterestInfo(amount);
            return amount;
        }

        public static void TransactionEnd(IRekening rekening)
        {
            StandardMessages.DisplayTransactionSuccessAccountInfo(rekening.Name, rekening.Number, rekening.Saldo);
        }
    }
}
