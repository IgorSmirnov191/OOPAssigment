using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class RekeningValidator
    {
        public static bool Validate(IRekening rekening)
        {
            //Checks to be sure the account's name is valid
            if (string.IsNullOrWhiteSpace(rekening.Name))
            {
                StandardMessages.DisplayValidationError("naam van de rekening");

                return false;
            }
            //Checks to be sure the account's number is valid
            if (string.IsNullOrWhiteSpace(rekening.Number))
            {
                StandardMessages.DisplayValidationError("rekeningnummer");

                return false;
            }
            //Checks to be sure the account is not locked
            if (rekening.IsLocked)
            {
                StandardMessages.AccountLockingError();
                return false;
            }
            return true;
        }
    }
}
