using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class Program
    {
        static void Main(string[] args)
        {
            double basicCapital = 1500.67;
            IRekening rekening = RekeningCapture.Capture(RekeningCapture.GetRekening("ProRekening"));

            bool isAccountValid = RekeningValidator.Validate(rekening);

            if (isAccountValid == false)
            {
                StandardMessages.TransactionFout();
                return;
            }
            try
            {
                TransactionGenerator.TransactionStart(rekening);
                TransactionGenerator.TransactionVoegGeldToe(rekening, basicCapital);
                double intrest = TransactionGenerator.TransactionBerekerenRente(rekening);
                TransactionGenerator.TransactionVoegGeldToe(rekening, intrest);
                TransactionGenerator.TransactionEnd(rekening);
            }
            catch (Exception ex)
            {
                StandardMessages.TransactionFout();
            }

            StandardMessages.EndApplication();

        }
    }
}
