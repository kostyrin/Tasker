using System;
using NLog;
using TaskerWindowsService.Domain;
using TaskerWindowsService.Services.ProcessServices;

namespace TaskerWindowsService.Services
{
    public class ScheduleProcessesWrapper
    {
        private static readonly ILogger _log = LogManager.GetLogger(typeof(ScheduleProcessesWrapper).Name, typeof(ScheduleProcessesWrapper));

        private readonly ICreateEmptyFileAfter10SecondsService _createEmptyFileAfter10SecondsService;
        private readonly ISendEmailService _sendEmailService;

        public ScheduleProcessesWrapper(ICreateEmptyFileAfter10SecondsService createEmptyFileAfter10SecondsService, ISendEmailService sendEmailService)
        {
            _createEmptyFileAfter10SecondsService = createEmptyFileAfter10SecondsService;
            _sendEmailService = sendEmailService;
        }

        public static bool ExecuteAction(Func<bool> process)
        {
            try
            {
                return process();
            }
            catch (Exception e)
            {
                _log.Error(e);
                return true;
            }
        }

        public bool CreateEmptyFileAfter10Seconds(Schedule schedule)
        {
            return _createEmptyFileAfter10SecondsService.Process(schedule.Parameters);
        }

        public bool SendEmail(Schedule schedule)
        {
            return _sendEmailService.Process(schedule.Parameters);
        }


    }
}
