namespace BookmarkManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookmarkCloud cloud = new BookmarkCloud();
            cloud.SetBookMark(new BookMark("GoogleBe", "www.google.be"), 0);
            BookMark u = cloud.GetBookMark(0);
            u.OpenSite();

            cloud.ClearBookMark(0);
            u = cloud.GetBookMark(0);
            u.OpenSite();
        }
    }
}