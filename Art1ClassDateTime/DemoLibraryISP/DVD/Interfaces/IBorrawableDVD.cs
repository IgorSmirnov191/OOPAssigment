using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryISP
{
    public interface IBorrawableDVD : IDVD, IBorrowable
    {
    }
}
