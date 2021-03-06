using System;

namespace Money
{
    public class Program
    {
        private static void Main(string[] args)
        {
            double basicCapital = 1500.67;

            IRekening rekening = RekeningCapture.Capture(RekeningCapture.GetRekening("ProRekening", basicCapital));

            bool isAccountValid = RekeningValidator.Validate(rekening);

            if (isAccountValid == false)
            {
                StandardMessages.OperationFoutEnterToClose("Not validated.");
                return;
            }
            try
            {
                TransactionGenerator.TransactionStart(rekening);
                TransactionGenerator.TransactionVoegGeldToe(rekening, TransactionGenerator.TransactionBerekerenRente(rekening));
                TransactionGenerator.TransactionEnd(rekening);
            }
            catch (Exception ex)
            {
                StandardMessages.OperationFoutEnterToClose($"Transaction is aborted. {ex.Message}");
            }

            StandardMessages.EndApplicationEnterKeyToClose();
        }
    }
}