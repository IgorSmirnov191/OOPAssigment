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
            //Checks to be sure the account's name and number are valid
            if (string.IsNullOrWhiteSpace(rekening.Name))
            {
                StandardMessages.DisplayValidationError("naam van de rekening");

                return false;
            }

            if (string.IsNullOrWhiteSpace(rekening.Number))
            {
                StandardMessages.DisplayValidationError("rekeningnummer");

                return false;
            }

            if (rekening.IsLocked)
            {
                StandardMessages.AccountLockingError();
                return false;
            }
            return true;
        }
    }
}
