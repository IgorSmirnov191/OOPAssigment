using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BookmarkCloud cloud = new BookmarkCloud();
            cloud.SetBookMark(new BookMark("GoogleBe", "www.google.be"), 0);
            BookMark u = cloud.GetBookMark(0);
            u.OpenSite();
        }
    }
}
