using System.IO;
using System.Threading;

namespace TaskerWindowsService.Services.ProcessServices
{
    public class CreateEmptyFileAfter10SecondsService : ICreateEmptyFileAfter10SecondsService
    {
        public bool Process(string processParams)
        {
            Thread.Sleep(10000);

            File.Create($"{processParams}").Dispose();

            return true;
        }
    }
}
