using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class SpaarRekening : Rekening
    {
        public SpaarRekening() : base() { }
       
        public override double BerekenRente()
        {
            return Saldo * 0.02;
        }
    }
}
