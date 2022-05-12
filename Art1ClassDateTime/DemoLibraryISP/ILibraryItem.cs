using System;

namespace DemoLibraryISP
{
    public interface ILibraryItem
    {  
        string LibraryId { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Borrower { get; set; }
        DateTime BorrowerDate { get; set; }
        int CheckOutDurationInDays { get; set; }
      
        int Pages { get; set; }
       

        void CheckIn();
        void CheckOut(string borrower);
        DateTime GetDueDate();
    }
}