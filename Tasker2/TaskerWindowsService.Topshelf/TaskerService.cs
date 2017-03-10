using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerWindowsService.Services;

namespace TaskerWindowsService.Topshelf
{
    public class TaskerService : BaseService
    {
        private readonly ScheduleProcessService _eventService;

        public TaskerService(ScheduleProcessService eventService)
        {
            _eventService = eventService;
        }

        protected override void DoWork()
        {
            _eventService.GetAndDoProcess();
        }
    }
}
