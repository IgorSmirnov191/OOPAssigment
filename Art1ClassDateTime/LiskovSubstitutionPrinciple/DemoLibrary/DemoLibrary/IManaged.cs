namespace DemoLibrary
{
    public interface IManaged : IEmployee
    {
        IEmployee Manager { get; set; }

        void AssingManager(IEmployee manager);
    }
}