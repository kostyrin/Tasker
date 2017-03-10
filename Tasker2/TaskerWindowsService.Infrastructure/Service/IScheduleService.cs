using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerWindowsService.Domain;

namespace TaskerWindowsService.Infrastructure.Service
{
    public interface IScheduleService
    {
        Schedule GetAvaibleTask();
        void SetRunning(Schedule task);
        void SetFinished(Schedule task);
        void SetNotRuning(Schedule task);
        void Delete(Schedule task);
        void SetFailed(Schedule task);
    }
}
