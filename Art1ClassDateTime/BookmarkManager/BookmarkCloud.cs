using System;

namespace BookmarkManager
{
    internal class BookmarkCloud
    {
        private BookMark[] bookMarks;

        public BookmarkCloud()
        {
            bookMarks = new BookMark[5];
        }

        public BookMark GetBookMark(int index)
        {
            if (index < 0 || index >= bookMarks.Length)
            {
                Console.WriteLine("Error. Index is out of range");
            }
            else if (bookMarks[index] == null)
            {
                Console.WriteLine("Error. BookMark is empty");
            }
            else
            {
                return bookMarks[index];
            }
            return new BookMark("Empty Page", "about:blank");
        }

        public void SetBookMark(BookMark bookmark, int index)
        {
            if (index < 0 || index >= bookMarks.Length)
            {
                Console.WriteLine("Error. Index is out of range");
            }
            else
            {
                bookMarks[index] = bookmark;
            }
        }

        public void ClearBookMark(int index)
        {
            if (index < 0 || index >= bookMarks.Length)
            {
                Console.WriteLine("Error. Index is out of range");
            }
            else
            {
                bookMarks[index] = null;
            }
        }
    }
}