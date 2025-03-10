namespace BlazorApp.Shared.Services
{
    public interface ISharedService
    {
        string GetMessage();
    }

    public class SharedService : ISharedService
    {
        public string GetMessage() => "Hello from Shared Service!";
    }
}
