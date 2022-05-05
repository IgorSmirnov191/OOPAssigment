﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class ProRekening : SpaarRekening
    {
        public ProRekening() : base() { }
        public override double BerekenRente()
        {
            return Saldo >= 1000 ? Saldo * 0.03 : base.BerekenRente();
        }
    }
}
