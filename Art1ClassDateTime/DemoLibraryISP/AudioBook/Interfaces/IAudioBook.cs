namespace DemoLibraryISP
{
    public interface IAudioBook : ILibraryItem
    {
        int RuntimeInMinutes { get; set; }
    }
}