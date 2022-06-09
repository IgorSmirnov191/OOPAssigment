using System;

namespace DemoLibraryISP
{
    public class AudioBook : IBorrowableAudioBook
    {
        public string Author { get; set; }
        public string Borrower { get; set; }
        public DateTime BorrowerDate { get; set; }
        public int CheckOutDurationInDays { get; set; } = 14;
        public string LibraryId { get; set; }
        public int Pages { get; set; } = -1;
        public string Title { get; set; }

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