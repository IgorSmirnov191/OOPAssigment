using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class BankRekening : Rekening
    {
        public BankRekening():base() { }
        public override double BerekenRente()
        {
            if (Saldo > 100) return Saldo * 0.05;
            return 0;
        }

    }
}
