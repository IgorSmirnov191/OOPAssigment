using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryISP.DigitalMovie
{
    public class DigitalMovie : IBorrawableDVD
    {
        public string Borrower { get; set; }
        public DateTime BorrowerDate { get; set; }
        public int CheckOutDurationInDays { get; set; } = 14;
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public List<string> Actors { get; set; }
        public int RuntimeInMinutes { get; set; }

        public void CheckIn()
        {
            Borrower = "";
        }

        public void CheckOut(string borrower)
        {
            Borrower = borrower;
            BorrowerDate = DateTime.Now;
        }

        public DateTime GetDueDate()
        {
            return BorrowerDate.AddDays(CheckOutDurationInDays);
        }
    }
}
