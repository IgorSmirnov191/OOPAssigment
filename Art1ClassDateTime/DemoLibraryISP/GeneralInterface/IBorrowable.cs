using System;

namespace DemoLibraryISP
{
    public interface IBorrowable
    {
        string Borrower { get; set; }
        DateTime BorrowerDate { get; set; }
        int CheckOutDurationInDays { get; set; }

        void CheckIn();

        void CheckOut(string borrower);

        DateTime GetDueDate();
    }
}