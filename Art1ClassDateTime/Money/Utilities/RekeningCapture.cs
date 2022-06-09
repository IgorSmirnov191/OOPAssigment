using System;

namespace Money
{
    public class RekeningCapture
    {
        public static IRekening GetRekening(string rekeningType, double basicCapital = 0)
        {
            try
            {
                return (IRekening)Activator.CreateInstance(Type.GetType($"Money.{rekeningType}"), new Object[] { basicCapital });
            }
            catch (Exception e)
            {
                return new NullRekening();
            }
        }

        public static IRekening Capture(IRekening account)
        {
            //Ask for account information
            StandardMessages.DisplayInputMessageAccountName();
            account.Name = Console.ReadLine();

            StandardMessages.DisplayInputMessageAccountNumber();
            account.Number = Console.ReadLine();

            return account;
        }
    }
}