namespace TaskerWindowsService.Services.ProcessServices
{
    public interface ICreateEmptyFileAfter10SecondsService
    {
        bool Process(string processParams);
    }
}
