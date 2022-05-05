using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class RekeningCapture
    {
        public static IRekening GetRekening(string rekeningType)
        {
            try
            {

                return (IRekening)Activator.CreateInstance(Type.GetType($"Money.{rekeningType}"));

            }
            catch (Exception e)
            {
                return null;
            }
          
        }
        public static IRekening Capture(IRekening account)
        {
            if (account != null)
            {
                //Ask for account information
                Console.WriteLine("Geef een rekeningnaam: ");
                account.Name = Console.ReadLine();

                Console.WriteLine("Geef een rekeningnummer: ");
                account.Number = Console.ReadLine();

            }            
            return account;
        }
    }
}
